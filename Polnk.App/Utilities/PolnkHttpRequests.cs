namespace Polnk.App.Utilities;
public class PolnkHttpRequests
{
    private readonly IHttpClientService? httpClientService;

    public PolnkHttpRequests()
    {
        this.httpClientService = ServiceProvider.GetService<IHttpClientService>();
    }

    public async Task<LoginResponse> Login(LoginRequest loginRequest)
    {
        string loginResponseJson = await httpClientService!.LoginAsync(ApiRoutes.Login, loginRequest);
        return JsonSerializer.Deserialize<LoginResponse>(loginResponseJson)!;
    }

    public async Task<RegisterResponse> Register(RegisterRequest registerRequest)
    {           
         string registrationResponseJson = await httpClientService!.PostAsync(ApiRoutes.Register, registerRequest);
         return JsonSerializer.Deserialize<RegisterResponse>(registrationResponseJson)!;  
    }

    public async Task<RegisterProfilePicResponse> RegisterPic(string filePath)
    {
        string registrationPicResponseJson = await httpClientService!.MultipartImageUpload(ApiRoutes.RegisterProfilePic,filePath);
        return JsonSerializer.Deserialize<RegisterProfilePicResponse>(registrationPicResponseJson)!;
    }

    public async Task<UpdateUserInformationResponse>UpdateInfo(UpdateUserInformationRequest UpdateUser)
    {
        string UpdateInfoResponseJson = await httpClientService!.PatchAsync(ApiRoutes.UpdateUser,UpdateUser);
        return JsonSerializer.Deserialize<UpdateUserInformationResponse>(UpdateInfoResponseJson)!;
    }
}