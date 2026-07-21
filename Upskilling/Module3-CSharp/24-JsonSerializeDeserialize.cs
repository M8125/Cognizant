using System.Text.Json;

class User24
{
    public string Name { get; set; } = "";
    public int Age { get; set; }
    public string Email { get; set; } = "";
}

static class Task24_JsonSerializeDeserialize
{
    public static void Run()
    {
        var user = new User24 { Name = "Ivy", Age = 28, Email = "ivy@example.com" };
        var json = JsonSerializer.Serialize(user);

        var filePath = Path.Combine(Path.GetTempPath(), "user.json");
        File.WriteAllText(filePath, json);
        Console.WriteLine($"Serialized JSON: {json}");

        var loadedJson = File.ReadAllText(filePath);
        var deserialized = JsonSerializer.Deserialize<User24>(loadedJson);
        Console.WriteLine($"Deserialized: {deserialized?.Name}, {deserialized?.Age}, {deserialized?.Email}");

        System.Diagnostics.Debug.Assert(deserialized?.Name == "Ivy", "Deserialized user should match the original");

        File.Delete(filePath);
    }
}
