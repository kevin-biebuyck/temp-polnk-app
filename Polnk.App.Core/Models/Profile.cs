using Newtonsoft.Json;

namespace Polnk.App.Core.Models;

public class Profile
{
    [JsonProperty("publicId")]
    public string? PublicId { get; set; }
    [JsonProperty("contactEmail")]
    public string? ContactEmail { get; set; }
    [JsonProperty("firstName")]
    public string? FirstName { get; set; }
    [JsonProperty("lastName")]
    public string? LastName { get; set; }
    [JsonProperty("avatar")]
    public Dictionary<string, Uri> Avatar { get; init; }

    [JsonProperty("jobTitle")]
    public string? JobTitle { get; set; }
    [JsonProperty("skills")]
    public string[] Skills { get; set; }
    [JsonProperty("description")]
    public string? Description { get; set; }
}