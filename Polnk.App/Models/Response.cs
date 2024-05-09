namespace Polnk.App.Models;

public class Response
{
    public HttpStatusCode Status { get; set; }
    public string? Message { get; set; }

    [JsonPropertyName("error")]
    public string? Error { get; set; }

    [JsonPropertyName("error_description")]
    public string? ErrorDescription { get; set; }
}

