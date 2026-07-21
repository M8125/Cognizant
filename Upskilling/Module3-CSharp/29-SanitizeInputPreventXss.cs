using System.Net;

static class Task29_SanitizeInputPreventXss
{
    static string SanitizeInput(string rawInput) => WebUtility.HtmlEncode(rawInput);

    public static void Run()
    {
        string userInput = "<script>alert('XSS')</script>";
        Console.WriteLine($"Raw input: {userInput}");

        var sanitized = SanitizeInput(userInput);
        Console.WriteLine($"Sanitized for display: {sanitized}");
        System.Diagnostics.Debug.Assert(!sanitized.Contains("<script>"), "sanitized output should not contain a raw script tag");
    }
}
