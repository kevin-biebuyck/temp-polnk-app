namespace Polnk.App.Models.Requests;

public record UpdateUserInformationRequest
{
    public string op{ get; set; }

    public string path { get; set; }

    public string value { get; set; }
    public UpdateUserInformationRequest(string Op,string Path,string Value)
    {
        op = Op;
        path = Path;
        value = Value;
    }
}
