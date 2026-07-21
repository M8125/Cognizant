class Order20
{
    public int OrderId { get; set; }
    public string CustomerName { get; set; } = "";
    public decimal TotalAmount { get; set; }
}

static class Task20_LinqFilteringAndProjection
{
    public static void Run()
    {
        List<Order20> orders = new()
        {
            new Order20 { OrderId = 1, CustomerName = "Alice", TotalAmount = 150.00m },
            new Order20 { OrderId = 2, CustomerName = "Bob", TotalAmount = 45.00m },
            new Order20 { OrderId = 3, CustomerName = "Charlie", TotalAmount = 300.00m },
        };

        var highValue = orders
            .Where(o => o.TotalAmount > 100)
            .Select(o => new { o.OrderId, o.CustomerName });

        foreach (var o in highValue)
            Console.WriteLine($"Order {o.OrderId}: {o.CustomerName}");

        System.Diagnostics.Debug.Assert(highValue.Count() == 2, "Two orders should exceed 100");
    }
}
