class Product12
{
    public string Name { get; set; } = "";

    private decimal price;
    public decimal Price
    {
        get => price;
        set => price = value < 0 ? throw new ArgumentException("Price cannot be negative") : value;
    }
}

static class Task12_AutoPropertiesAndBackingFields
{
    public static void Run()
    {
        var product = new Product12 { Name = "Widget", Price = 9.99m };
        Console.WriteLine($"{product.Name}: {product.Price}");
        System.Diagnostics.Debug.Assert(product.Price == 9.99m, "Price should be set correctly");

        try
        {
            product.Price = -5;
            Console.WriteLine("Negative price was allowed (unexpected)");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Validation works: {ex.Message}");
        }
    }
}
