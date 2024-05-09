using Microsoft.AspNetCore.JsonPatch;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using Polnk.App.Core.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Polnk.App.Core.Models.CurriculumVitaes;
using System.Reflection.Metadata;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Polnk.App.Models.Responses;
using JsonSerializer = System.Text.Json.JsonSerializer;
using System.IO;

namespace Polnk.App.Core
{
    public class PolnkClient(IOptions<PolnkConfig> config, HttpClient client, IAuthStore authStore)
    {
        // Auth
        public async Task<(RegisterResponse? result, Exception? error)> Register(string email, string password) => await SendAndReadJson<RegisterResponse>(await BuildRequest(HttpMethod.Post, "register", false, new { email, password }));

        // Profile
        public async Task<(Profile? result, Exception? error)> GetProfile() => await SendAndReadJson<Profile>(await BuildRequest(HttpMethod.Get, $"profile/{await ExtractUserId()}/personal", true));
        public async Task<(Profile? result, Exception? error)> PatchProfile(JsonPatchDocument<Profile> patchProfile) => await SendAndReadJson<Profile>(await BuildRequest(HttpMethod.Patch, $"profile/{await ExtractUserId()}/personal", true, patchProfile));
        public async Task<(Profile? result, Exception? error)> SetAvatar(ByteArrayContent content, string fileName) => await SendAndReadJson<Profile>(await BuildRequest(HttpMethod.Put, $"profile/{await ExtractUserId()}/avatar", true, new MultipartFormDataContent { { content, "file", fileName } }));
        
        // Upload video
        public async Task<(DirectUploadLink? result, Exception? error)> CreateUploadLink() => await SendAndReadJson<DirectUploadLink>(await BuildRequest(HttpMethod.Post, $"profile/{await ExtractUserId()}/video", true));
        public async Task<(Profile? result, Exception? error)> UploadVideo(DirectUploadLink videoUploadLink, ByteArrayContent content, string fileName) => await SendAndReadJson<Profile>(new HttpRequestMessage(HttpMethod.Post, videoUploadLink.UploadUrl) { Content = new MultipartFormDataContent { { content, "file", fileName } } });

        // CV
        public async Task<(CurriculumVitae? result, Exception? error)> GetCurriculumVitae(string cvId = "main") => await SendAndReadJson<CurriculumVitae>(await BuildRequest(HttpMethod.Get, $"profile/{await ExtractUserId()}/personal/curriculum-vitae/{cvId}", true));
        public async Task<(CurriculumVitae? result, Exception? error)> PatchCurriculumVitae(JsonPatchDocument<CurriculumVitae> patchCurriculumVitae, string cvId = "main") => await SendAndReadJson<CurriculumVitae>(await BuildRequest(HttpMethod.Patch, $"profile/{await ExtractUserId()}/personal/curriculum-vitae/{cvId}", true, patchCurriculumVitae));


        internal async Task<HttpRequestMessage> BuildRequest<T>(HttpMethod verb, string path, bool useJwtToken, JsonPatchDocument<T> patch) where T : class => await BuildRequest(verb, path, useJwtToken, new StringContent(JsonConvert.SerializeObject(patch, new JsonSerializerSettings() { ContractResolver = patch.ContractResolver }), Encoding.UTF8, "application/json"));

        internal async Task<HttpRequestMessage> BuildRequest(HttpMethod verb, string path, bool useJwtToken, object? body) => await BuildRequest(verb, path, useJwtToken, new StringContent(JsonSerializer.Serialize(body, new JsonSerializerOptions()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        }), Encoding.UTF8, "application/json"));
        internal async Task<HttpRequestMessage> BuildRequest(HttpMethod verb, string path, bool useJwtToken, HttpContent? body = null)
        {
            var request = new HttpRequestMessage(verb, new Uri(new Uri(config.Value.Host), path)) { Content = body };

            if (useJwtToken)
                request.Headers.Authorization = AuthenticationHeaderValue.Parse($"Bearer {await authStore.GetAccessToken()}");

            return request;
        }

        private async Task<(TResult?, Exception? error)> SendAndReadJson<TResult>(HttpRequestMessage message) where TResult : class
        {
            try
            {
                var response = await client.SendAsync(message);
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                return (JsonSerializer.Deserialize<TResult>(body, new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase }), null);
            }
            catch (Exception ex)
            {
                return (null, ex);
            }
        }

        private async Task<string> ExtractUserId()
        {
            var token = await authStore.GetAccessToken();

            var handler = new JwtSecurityTokenHandler();
            var jsonToken = (JwtSecurityToken)handler.ReadToken(token);

            return jsonToken.Payload.Sub.Split("|").Last();
        }
    }
}
