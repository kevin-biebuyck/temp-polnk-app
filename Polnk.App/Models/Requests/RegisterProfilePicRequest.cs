namespace Polnk.App.Models.Requests;

public record RegisterProfilePicRequest
{
    public MediaFile Photo {  get; set; }
    public RegisterProfilePicRequest(MediaFile photo)
    {
        Photo = photo;
    }
}
