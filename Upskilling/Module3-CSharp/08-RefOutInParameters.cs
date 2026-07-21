static class Task08_RefOutInParameters
{
    static void UseRef(ref int x) => x *= 2;
    static void UseOut(out int x) => x = 42;
    static void UseIn(in int x) => Console.WriteLine($"in parameter (read-only): {x}");

    public static void Run()
    {
        int refValue = 5;
        Console.WriteLine($"Before ref: {refValue}");
        UseRef(ref refValue);
        Console.WriteLine($"After ref: {refValue}");
        System.Diagnostics.Debug.Assert(refValue == 10, "ref parameter should double the value");

        Console.WriteLine("Before out: (uninitialized)");
        UseOut(out int outValue);
        Console.WriteLine($"After out: {outValue}");
        System.Diagnostics.Debug.Assert(outValue == 42, "out parameter must be assigned by the callee");

        int inValue = 7;
        UseIn(in inValue);
        System.Diagnostics.Debug.Assert(inValue == 7, "in parameter must not be modified by the callee");
    }
}
