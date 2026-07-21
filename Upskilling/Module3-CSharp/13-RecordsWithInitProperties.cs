record Employee13
{
    public required string Name { get; init; }
    public required decimal Salary { get; init; }
}

static class Task13_RecordsWithInitProperties
{
    public static void Run()
    {
        var original = new Employee13 { Name = "Dana", Salary = 50000m };
        var raised = original with { Salary = 55000m };

        Console.WriteLine($"Original: {original.Name}, {original.Salary}");
        Console.WriteLine($"Raised copy: {raised.Name}, {raised.Salary}");
        System.Diagnostics.Debug.Assert(original.Salary == 50000m && raised.Salary == 55000m, "with-expression should copy without mutating the original");
    }
}
