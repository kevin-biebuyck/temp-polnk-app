


using Microsoft.AspNetCore.JsonPatch;
using Microsoft.Extensions.Options;
using Polnk.App.Core;
using Polnk.App.Core.Models;
using System.IO;
using System.Text.Json;
using Polnk.App.Core.Models.CurriculumVitaes;

var authStorage = new DummyAuthStorage();
var client = new PolnkClient(new OptionsWrapper<PolnkConfig>(new PolnkConfig()), new HttpClient(), authStorage);

// Register
var authResult = await client.Register($"test-email-{DateTime.Now.Ticks}@polnk.io", "test-password");
if (authResult.error != null)
    throw new AggregateException(authResult.error);
await authStorage.StoreToken(authResult.result!.AccessToken!, authResult.result!.RefreshToken!);
Console.WriteLine("Registered");
Console.WriteLine(JsonSerializer.Serialize(authResult.result, new JsonSerializerOptions() { WriteIndented = true }));

// Set profile
var profile = await client.PatchProfile(new JsonPatchDocument<Profile>()
    .Replace(x => x.FirstName, "Test firstname")
    .Replace(x => x.LastName, "Test firstname")
    .Replace(x => x.ContactEmail, "some-email@polnk.io"));
if (profile.error != null)
    throw new AggregateException(profile.error);
Console.WriteLine("Profile set");
Console.WriteLine(JsonSerializer.Serialize(profile.result, new JsonSerializerOptions() { WriteIndented = true }));

// Set Avatar
var content = new ByteArrayContent(File.ReadAllBytes("2020-05-12_22-58-36.png"));
content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/png");
var avatar = await client.SetAvatar(content, "2020-05-12_22-58-36.png");
if (avatar.error != null)
    throw new AggregateException(avatar.error);
Console.WriteLine("Avatar set");
Console.WriteLine(JsonSerializer.Serialize(avatar.result, new JsonSerializerOptions() { WriteIndented = true }));


// Set Professional infos
profile = await client.PatchProfile(new JsonPatchDocument<Profile>()
    .Replace(x => x.Description, "Test description")
    .Replace(x => x.JobTitle, "Test job title")
    .Replace(x => x.Skills, new[] { "Skill 1", "Skill 2" })
);
if (profile.error != null)
    throw new AggregateException(profile.error);
Console.WriteLine("Professional infos set");
Console.WriteLine(JsonSerializer.Serialize(profile.result, new JsonSerializerOptions() { WriteIndented = true }));

/*******************************************************************************************************************/
/****************************************** Self presentation ******************************************************/
/*******************************************************************************************************************/

var selfPres = new SelfPresentationCurriculumVitaeAnswer();

// Upload video
var videoUploadLink = await client.CreateUploadLink();
if (videoUploadLink.result == null)
    throw new AggregateException(videoUploadLink.error!);
content = new ByteArrayContent(File.ReadAllBytes("file_example_MP4_480_1_5MG.mp4"));
content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("video/mp4");
await client.UploadVideo(videoUploadLink.result, content, selfPres.AnswerId);

// Patch CV with video section
selfPres.VideoId = videoUploadLink.result.VideoId;
var cv = await client.PatchCurriculumVitae(new JsonPatchDocument<CurriculumVitae>().
    Replace(x => x.Answers[selfPres.AnswerId], selfPres)
);
if (cv.error != null)
    throw new AggregateException(cv.error);
Console.WriteLine("Self presentation set");
Console.WriteLine(JsonSerializer.Serialize(cv.result, new JsonSerializerOptions() { WriteIndented = true }));


/*******************************************************************************************************************/
/************************************************ Language *********************************************************/
/*******************************************************************************************************************/

var language = new LanguageCurriculumVitaeAnswer() { Language = "English", Level = Level.Medium };

// Upload video
videoUploadLink = await client.CreateUploadLink();
if (videoUploadLink.result == null)
    throw new AggregateException(videoUploadLink.error!);
content = new ByteArrayContent(File.ReadAllBytes("file_example_MP4_480_1_5MG.mp4"));
content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("video/mp4");
await client.UploadVideo(videoUploadLink.result, content, language.AnswerId);

// Patch CV with video section
language.VideoId = videoUploadLink.result.VideoId;
cv = await client.PatchCurriculumVitae(new JsonPatchDocument<CurriculumVitae>().
    Replace(x => x.Answers[language.AnswerId], language)
);
if (cv.error != null)
    throw new AggregateException(cv.error);
Console.WriteLine("Language set");
Console.WriteLine(JsonSerializer.Serialize(cv.result, new JsonSerializerOptions() { WriteIndented = true }));


/*******************************************************************************************************************/
/************************************************ Education ********************************************************/
/*******************************************************************************************************************/

var eduction = new EducationCurriculumVitaeAnswer() { SchoolName = "Great school", Degree = Degree.Licence, From = DateOnly.Parse("01/01/2015"), To = DateOnly.Parse("01/01/2019") };

// Upload video
videoUploadLink = await client.CreateUploadLink();
if (videoUploadLink.result == null)
    throw new AggregateException(videoUploadLink.error!);
content = new ByteArrayContent(File.ReadAllBytes("file_example_MP4_480_1_5MG.mp4"));
content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("video/mp4");
await client.UploadVideo(videoUploadLink.result, content, eduction.AnswerId);

// Patch CV with video section
eduction.VideoId = videoUploadLink.result.VideoId;
cv = await client.PatchCurriculumVitae(new JsonPatchDocument<CurriculumVitae>().
    Replace(x => x.Answers[eduction.AnswerId], eduction)
);
if (cv.error != null)
    throw new AggregateException(cv.error);
Console.WriteLine("Education set");
Console.WriteLine(JsonSerializer.Serialize(cv.result, new JsonSerializerOptions() { WriteIndented = true }));