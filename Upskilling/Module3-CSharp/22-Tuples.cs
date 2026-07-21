static class Task22_Tuples
{
    static (int Count, string Message) GetSummary() => (5, "Five items processed");

    public static void Run()
    {
        var (count, message) = GetSummary();
        Console.WriteLine($"Count: {count}, Message: {message}");
        System.Diagnostics.Debug.Assert(count == 5 && message == "Five items processed", "tuple deconstruction should match the returned values");
    }
}
