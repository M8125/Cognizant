class BaseClass11
{
    public string PublicField = "public";
    private string privateField = "private";
    protected string protectedField = "protected";

    public string ShowFromInside() => $"{PublicField}, {privateField}, {protectedField}";
}

class DerivedClass11 : BaseClass11
{
    public string ShowFromDerived() => $"{PublicField}, {protectedField}";
}

static class Task11_AccessModifiers
{
    public static void Run()
    {
        var baseObj = new BaseClass11();
        Console.WriteLine($"Non-derived access: {baseObj.PublicField}");
        Console.WriteLine($"From inside the class: {baseObj.ShowFromInside()}");

        var derived = new DerivedClass11();
        Console.WriteLine($"From derived class: {derived.ShowFromDerived()}");
        System.Diagnostics.Debug.Assert(baseObj.PublicField == "public", "public members should be accessible everywhere");
    }
}
