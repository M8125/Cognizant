class Car10
{
    public string Make;
    public string Model;
    public int Year;

    public Car10()
    {
        Make = "Unknown";
        Model = "Unknown";
        Year = 0;
    }

    public Car10(string make, string model, int year)
    {
        Make = make;
        Model = model;
        Year = year;
    }

    public override string ToString() => $"{Year} {Make} {Model}";
}

static class Task10_OopBasicsWithConstructors
{
    public static void Run()
    {
        var defaultCar = new Car10();
        var customCar = new Car10("Toyota", "Corolla", 2023);

        Console.WriteLine(defaultCar);
        Console.WriteLine(customCar);

        System.Diagnostics.Debug.Assert(defaultCar.Make == "Unknown" && customCar.Make == "Toyota" && customCar.Year == 2023, "constructor overload set the wrong fields");
    }
}
