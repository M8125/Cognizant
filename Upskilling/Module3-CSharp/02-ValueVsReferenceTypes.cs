class Counter02
{
    public int Value;
}

static class Task02_ValueVsReferenceTypes
{
    static void ModifyValueType(int x) => x = 100;
    static void ModifyReferenceType(Counter02 c) => c.Value = 100;

    public static void Run()
    {
        int number = 5;
        Console.WriteLine($"Before (value type): {number}");
        ModifyValueType(number);
        Console.WriteLine($"After (value type): {number}");
        System.Diagnostics.Debug.Assert(number == 5, "value type unchanged after call");

        Counter02 counter = new() { Value = 5 };
        Console.WriteLine($"Before (reference type): {counter.Value}");
        ModifyReferenceType(counter);
        Console.WriteLine($"After (reference type): {counter.Value}");
        System.Diagnostics.Debug.Assert(counter.Value == 100, "reference type changed after call");
    }
}
