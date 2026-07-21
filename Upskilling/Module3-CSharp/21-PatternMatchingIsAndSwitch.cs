static class Task21_PatternMatchingIsAndSwitch
{
    static string DescribeWithIs(object obj)
    {
        if (obj is int i) return $"int: {i}";
        if (obj is string s) return $"string: {s}";
        if (obj is double d) return $"double: {d}";
        return "unknown type";
    }

    static string DescribeWithSwitch(object obj) => obj switch
    {
        int i => $"int: {i}",
        string s => $"string: {s}",
        double d => $"double: {d}",
        _ => "unknown type"
    };

    public static void Run()
    {
        object[] values = { 42, "hello", 3.14, true };
        foreach (var v in values)
        {
            Console.WriteLine($"is-pattern: {DescribeWithIs(v)}");
            Console.WriteLine($"switch-pattern: {DescribeWithSwitch(v)}");
        }

        System.Diagnostics.Debug.Assert(DescribeWithIs(42) == DescribeWithSwitch(42), "Both pattern-matching approaches must agree");
    }
}
