static class Task19_ListsAndDictionaries
{
    public static void Run()
    {
        List<string> names = new() { "Alice", "Bob", "Charlie" };
        Dictionary<int, string> idToName = new()
        {
            [1] = "Alice",
            [2] = "Bob",
            [3] = "Charlie"
        };

        Console.WriteLine("List:");
        foreach (var name in names) Console.WriteLine(name);

        Console.WriteLine("Dictionary:");
        foreach (var kvp in idToName) Console.WriteLine($"{kvp.Key}: {kvp.Value}");

        names.Add("Diana");
        names.Remove("Bob");
        idToName[4] = "Diana";
        idToName.Remove(2);

        Console.WriteLine("After add/remove:");
        foreach (var name in names) Console.WriteLine(name);
        foreach (var kvp in idToName) Console.WriteLine($"{kvp.Key}: {kvp.Value}");

        System.Diagnostics.Debug.Assert(names.Contains("Diana") && !names.Contains("Bob") && idToName.ContainsKey(4) && !idToName.ContainsKey(2), "add/remove should work on both collections");
    }
}
