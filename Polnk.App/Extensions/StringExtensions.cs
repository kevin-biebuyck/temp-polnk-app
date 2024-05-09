namespace Polnk.App.Extensions;

public static class StringExtensions
{
    public static bool IsNullOrEmpty(this string value)
    {
        return string.IsNullOrEmpty(value);
    }

    public static bool IsNotNullOrEmpty(this string value)
    {
        return !string.IsNullOrEmpty(value);
    }

    public static string GetStringSha256Hash(this string text)
    { 
        if (text.IsNullOrEmpty())
            return string.Empty;

        byte[] textData = Encoding.UTF8.GetBytes(text);
        byte[] hash = System.Security.Cryptography.SHA256.HashData(textData);
        return BitConverter.ToString(hash).Replace("-", string.Empty);
    }

    public static string FirstCharToUpper(this string input)
    {
        return input switch
        {
            null => throw new ArgumentNullException(nameof(input)),
            "" => throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input)),
            _ => string.Concat(input.First().ToString().ToUpper(), input.AsSpan(1)),
        };
    }
}

