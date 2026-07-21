static class Task01_HelloWorld
{
    public static void Run()
    {
        Console.WriteLine("Hello World");
        System.Diagnostics.Debug.Assert(Environment.Version.Major >= 8, ".NET 8+ expected");
    }
}
