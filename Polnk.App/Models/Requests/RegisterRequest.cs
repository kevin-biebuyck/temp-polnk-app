namespace Polnk.App.Models.Requests;

public record RegisterRequest
{
    public string email { get; set; }
    public string password { get; set; }

    public RegisterRequest(string Email, string Password)
    {
        email = Email;
        password = Password;
    }
}
