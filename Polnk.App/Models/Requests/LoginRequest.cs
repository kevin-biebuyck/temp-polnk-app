namespace Polnk.App.Models.Requests;

public record LoginRequest
{
    public string Email { get; set; }
    public string Password { get; set; }

    public LoginRequest(string email, string password)
    {
        Email = email;
        Password = password;
    }
}