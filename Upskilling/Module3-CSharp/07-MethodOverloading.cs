static class Task07_MethodOverloading
{
    static int CalculateTotal(int a, int b) => a + b;
    static double CalculateTotal(double a, double b, double c) => a + b + c;
    static int CalculateTotal(params int[] values)
    {
        int sum = 0;
        foreach (var v in values) sum += v;
        return sum;
    }

    public static void Run()
    {
        var r1 = CalculateTotal(2, 3);
        var r2 = CalculateTotal(1.5, 2.5, 3.0);
        var r3 = CalculateTotal(1, 2, 3, 4);

        Console.WriteLine($"Two ints: {r1}");
        Console.WriteLine($"Three doubles: {r2}");
        Console.WriteLine($"Params array: {r3}");

        System.Diagnostics.Debug.Assert(r1 == 5 && r2 == 7.0 && r3 == 10, "overload resolution picked the wrong signature");
    }
}
