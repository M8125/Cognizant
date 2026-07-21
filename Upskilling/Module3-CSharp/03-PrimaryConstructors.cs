class Person03(string name, int age)
{
    public string Name { get; } = name;
    public int Age { get; } = age;

    public string FullInfo() => $"{Name} is {Age} years old";
}

static class Task03_PrimaryConstructors
{
    public static void Run()
    {
        var person = new Person03("Alice", 30);
        Console.WriteLine($"Name: {person.Name}, Age: {person.Age}");
        Console.WriteLine(person.FullInfo());
        System.Diagnostics.Debug.Assert(person.Name == "Alice" && person.Age == 30, "primary constructor should set both properties");
    }
}
