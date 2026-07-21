class Student18
{
    public required string Name { get; set; }
    public required int Grade { get; set; }
}

static class Task18_RequiredModifier
{
    public static void Run()
    {
        var student = new Student18 { Name = "Grace", Grade = 9 };
        Console.WriteLine($"{student.Name}, grade {student.Grade}");
        // var invalid = new Student18 { Name = "Henry" }; // CS9035, Grade missing
        System.Diagnostics.Debug.Assert(student.Name == "Grace", "required properties must be set via object initializer");
    }
}
