class Contact17
{
    public string? Name { get; set; }
    public string? PhoneNumber { get; set; }
}

static class Task17_NullConditionalChainingContactApp
{
    static void PrintContactName(Contact17? contact)
    {
        var name = contact?.Name;
        if (name != null)
            Console.WriteLine($"Contact name: {name}");
        else
            Console.WriteLine("Contact name not available");
    }

    public static void Run()
    {
        var withName = new Contact17 { Name = "Frank", PhoneNumber = "555-1234" };
        var withoutName = new Contact17 { PhoneNumber = "555-5678" };
        Contact17? noContact = null;

        PrintContactName(withName);
        PrintContactName(withoutName);
        PrintContactName(noContact);

        System.Diagnostics.Debug.Assert(withName?.Name == "Frank" && noContact?.Name == null, "null contact should resolve safely instead of throwing");
    }
}
