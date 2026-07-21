static class Task09_LocalFunctions
{
    static long CalculateFactorial(int n)
    {
        long LocalFactorial(int k) => k <= 1 ? 1 : k * LocalFactorial(k - 1);
        return LocalFactorial(n);
    }

    public static void Run()
    {
        var result = CalculateFactorial(5);
        Console.WriteLine($"5! = {result}");
        System.Diagnostics.Debug.Assert(result == 120, "5! should equal 120");
    }
}
