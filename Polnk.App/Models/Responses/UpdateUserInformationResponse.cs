namespace Polnk.App.Models.Responses;
public class UpdateUserInformationResponse
{
     [JsonPropertyName("publicId")]
    public string? PublicId { get; set; }

    [JsonPropertyName("contactEmail")]
    public string? ContactEmail { get; set; }

    [JsonPropertyName("firstName")]
    public string? FirstName { get; set; }

    [JsonPropertyName("lastName")]
    public string? LastName { get; set; }

    [JsonPropertyName("avatar")]
    public Avatar? Avatar { get; set; }
 
    [JsonPropertyName("thumbnail")]
    public string? Thumbnail { get; set; }

    [JsonPropertyName("original")]
    public string? Original { get; set; }

    [JsonPropertyName("public")]
    public string? Public { get; set; }

    [JsonPropertyName("error")]
    public string? Error { get; set; }

    [JsonPropertyName("error_description")]
    public string? ErrorDescription { get; set; }
}
