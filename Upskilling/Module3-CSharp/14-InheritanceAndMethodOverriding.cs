class Shape14
{
    public virtual string Draw() => "Drawing a generic shape";
}

class Circle14 : Shape14
{
    public override string Draw() => "Drawing a circle";
}

class Rectangle14 : Shape14
{
    public override string Draw() => "Drawing a rectangle";
}

static class Task14_InheritanceAndMethodOverriding
{
    public static void Run()
    {
        Shape14 circle = new Circle14();
        Shape14 rectangle = new Rectangle14();

        Console.WriteLine(circle.Draw());
        Console.WriteLine(rectangle.Draw());

        System.Diagnostics.Debug.Assert(circle.Draw() == "Drawing a circle" && rectangle.Draw() == "Drawing a rectangle", "override should win over the base implementation");
    }
}
