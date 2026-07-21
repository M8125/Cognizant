class Animal04
{
    public string Name = "Generic Animal";
}

static class Task04_TypeInferenceWithVar
{
    public static void Run()
    {
        var count = 5;
        var name = "Charlie";
        var animal = new Animal04();

        Console.WriteLine($"{count.GetType()} -> {count}");
        Console.WriteLine($"{name.GetType()} -> {name}");
        Console.WriteLine($"{animal.GetType()} -> {animal.Name}");
        System.Diagnostics.Debug.Assert(count.GetType() == typeof(int) && name.GetType() == typeof(string) && animal.GetType() == typeof(Animal04), "var should infer the actual right-hand type");
    }
}
