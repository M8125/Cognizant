class Person16
{
    public string? Name { get; set; }
}

static class Task16_HandleNullReferencesSafely
{
    public static void Run()
    {
        Person16? person = new Person16 { Name = "Eve" };
        Console.WriteLine($"Name via ?. : {person?.Name}");
        Console.WriteLine($"Name with fallback via ?? : {person?.Name ?? "Unknown"}");

        Person16? missing = null;
        Console.WriteLine($"Null object via ?. : {missing?.Name}");
        Console.WriteLine($"Null object with fallback via ?? : {missing?.Name ?? "Unknown"}");

        System.Diagnostics.Debug.Assert(person?.Name == "Eve" && (missing?.Name ?? "Unknown") == "Unknown", "null-conditional and fallback should both behave");
    }
}
