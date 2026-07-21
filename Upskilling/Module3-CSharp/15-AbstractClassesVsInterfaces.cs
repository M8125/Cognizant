abstract class Vehicle15
{
    public abstract string Drive();
}

interface IDrivable15
{
    string Start();
}

class Car15 : Vehicle15, IDrivable15
{
    public override string Drive() => "Car is driving";
    public string Start() => "Car is starting";
}

static class Task15_AbstractClassesVsInterfaces
{
    public static void Run()
    {
        var car = new Car15();
        Console.WriteLine(car.Start());
        Console.WriteLine(car.Drive());

        Vehicle15 asVehicle = car;
        IDrivable15 asDrivable = car;

        Console.WriteLine(asVehicle.Drive());
        Console.WriteLine(asDrivable.Start());

        System.Diagnostics.Debug.Assert(asVehicle.Drive() == "Car is driving" && asDrivable.Start() == "Car is starting", "Car should satisfy both contracts");
    }
}
