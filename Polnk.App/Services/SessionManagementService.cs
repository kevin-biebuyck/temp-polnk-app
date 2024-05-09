namespace Polnk.App.Services;

public interface ISessionManagementService
{
    Task SetSession(string key, string value);
    string GetSession(string key);
    Task SetSession<T>(string key, T value);
    T GetSession<T>(string key);
    void RemoveSession(string key);
    void RemoveAllSession();
}

public class SessionManagementService: ISessionManagementService
{
    public async Task SetSession(string key, string value)
    {
        await SecureStorage.SetAsync(key, value);
    }

    public string GetSession(string key)
    {
        return SecureStorage.GetAsync(key).Result!;
    }

    public async Task SetSession<T>(string key, T value)
    {
        var jsonValue = JsonSerializer.Serialize(value);
        await SecureStorage.SetAsync(key, jsonValue);
    }

    public T GetSession<T>(string key)
    {
        var jsonResult = SecureStorage.GetAsync(key).Result!;
        return JsonSerializer.Deserialize<T>(jsonResult)!;
    }

    public void RemoveSession(string key)
    {
        SecureStorage.Remove(key);
    }

    public void RemoveAllSession()
    {
        SecureStorage.RemoveAll();
    }

}