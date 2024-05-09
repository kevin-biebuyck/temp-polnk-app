
namespace Polnk.App.Services;
public interface IHttpClientService
{
    Task<string> LoginAsync(string uri, LoginRequest model);
    Task<string> GetAsync(string uri);
    Task<string> PostAsync<T>(string uri, T item);
    Task<string> PutAsync<T>(string uri, T item);
    Task<string> MultipartImageUpload(string uri, string filepath);
    Task<string> DeleteAsync<T>(string uri, T item);
    Task<string> PatchAsync<T>(string uri, T item);

}

public class HttpClientService : IHttpClientService
{
    private readonly HttpClient client;
    private readonly ISessionManagementService sessionManagementService;

    public HttpClientService(ISessionManagementService sessionManagementService)
    {
        client = new();
        this.sessionManagementService = sessionManagementService;
    }

    public async Task<string> GetAsync(string uri)
    {
        HttpRequestMessage requestMessage = new(HttpMethod.Get, uri);

        return await InitializerHttpRequest(requestMessage);
    }

    public async Task<string> PostAsync<T>(string uri, T item)
    {       
            string serializedJson = JsonSerializer.Serialize(item);
            var requestContent = new StringContent(serializedJson, Encoding.UTF8, "application/json");      
            
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, uri)
            {
                Content = requestContent
            };

          return await InitializerHttpRequest(requestMessage);
    }


    public async Task<string> PutAsync<T>(string uri, T item)
    {
        string serializedJson = JsonSerializer.Serialize(item);
        var requestMessage = new HttpRequestMessage(HttpMethod.Put, uri)
        {
            Content = new StringContent(JsonSerializer.Serialize(item), Encoding.UTF8, "application/json")
        };

        return await InitializerHttpRequest(requestMessage);
    }

    public async Task<string> MultipartImageUpload(string uri, string filePath)
    {
        try
        {
            // Create a FileStream to read the file
            using (var fileStream = File.OpenRead(filePath))
            {
                // Create a StreamContent object from the FileStream
                var fileContent = new StreamContent(fileStream);

                // Create a multipart form data content
                var multipartFormDataContent = new MultipartFormDataContent();

                // Add the file content to the multipart form data
                multipartFormDataContent.Add(fileContent, "file", Path.GetFileName(filePath));

                // Set the Content-Type header to "multipart/form-data" (optional, since it's already set by default)
                 multipartFormDataContent.Headers.ContentType.MediaType = "multipart/form-data";

                // Create the HTTP request message
                var requestMessage = new HttpRequestMessage(HttpMethod.Put, uri)
                {
                    Content = multipartFormDataContent
                };
                 var contentString = await requestMessage.Content.ReadAsStringAsync();
                // Send the HTTP request and return the response
                return await InitializerHttpRequest(requestMessage);
            }
        }
        catch (Exception ex)
        {
            // Handle exceptions
            Console.WriteLine($"An error occurred: {ex.Message}");
            throw; // Rethrow the exception to handle it at a higher level if needed
        }
    }


    public async Task<string> DeleteAsync<T>(string uri, T item)
    {
        var requestMessage = new HttpRequestMessage(HttpMethod.Delete, uri)
        {
            Content = new StringContent(JsonSerializer.Serialize(item), Encoding.UTF8, "application/json")
        };

        return await InitializerHttpRequest(requestMessage);
    }
    public async Task<string> PatchAsync<T>(string uri, T item)
    {
            string serializedJson = JsonSerializer.Serialize(item);
        var requestMessage = new HttpRequestMessage(HttpMethod.Patch, uri)
        {
            Content = new StringContent(JsonSerializer.Serialize(item), Encoding.UTF8, "application/json")
        };

        return await InitializerHttpRequest(requestMessage);
    }


    public async Task<string> LoginAsync(string uri, LoginRequest model)
    {
        var nvc = new Dictionary<string, string>
        {
            [HttpHeadersConstants.GRANT_TYPE] = HttpHeadersConstants.GRANT_TYPE_PASSWORD,
            [HttpHeadersConstants.SCOPE] = HttpHeadersConstants.SCOPE_VALUE,
            [HttpHeadersConstants.CLIENT_ID] = HttpHeadersConstants.CLIENT_ID_VALUE,
            [HttpHeadersConstants.CLIENT_SECRET] = HttpHeadersConstants.CLIENT_SECRET_VALUE,
            [HttpHeadersConstants.AUDIENCE] = HttpHeadersConstants.AUDIENCEVALUE,
            ["username"] = model.Email, // Assuming "username" is the correct key
            ["password"] = model.Password
        };

        using var requestMessage = new HttpRequestMessage(HttpMethod.Post, uri) { Content = new FormUrlEncodedContent(nvc) };

        var response = await client.SendAsync(requestMessage);

        if (response.StatusCode == HttpStatusCode.InternalServerError)
        {
            throw new HttpRequestException();
        }

        return await response.Content.ReadAsStringAsync();
    }


    private async Task<string> InitializerHttpRequest(HttpRequestMessage requestMessage)
    {
        string token = sessionManagementService.GetSession(SessionKey.ACCESS_TOKEN);

        if (token.IsNotNullOrEmpty())
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var response = await client.SendAsync(requestMessage);

        return await response.Content.ReadAsStringAsync();
    }
}