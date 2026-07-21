using Microsoft.EntityFrameworkCore;

await using var context = new AppDbContext();

await Lab4_InsertInitialData(context);
await Lab5_RetrieveData(context);
await Lab6_UpdateAndDelete(context);
await Lab7_LinqQueries(context);

static async Task Lab4_InsertInitialData(AppDbContext context)
{
    if (await context.Categories.AnyAsync())
    {
        Console.WriteLine("Lab 4: data already seeded, skipping insert.");
        return;
    }

    var electronics = new Category { Name = "Electronics" };
    var groceries = new Category { Name = "Groceries" };
    await context.Categories.AddRangeAsync(electronics, groceries);

    var laptop = new Product { Name = "Laptop", Price = 75000, Category = electronics };
    var riceBag = new Product { Name = "Rice Bag", Price = 1200, Category = groceries };
    await context.Products.AddRangeAsync(laptop, riceBag);

    await context.SaveChangesAsync();
    Console.WriteLine("Lab 4: inserted categories and products.");
}

static async Task Lab5_RetrieveData(AppDbContext context)
{
    Console.WriteLine("\nLab 5: all products");
    var products = await context.Products.ToListAsync();
    foreach (var p in products)
        Console.WriteLine($"{p.Name} - {p.Price}");

    var byId = await context.Products.FindAsync(1);
    Console.WriteLine($"Found by id 1: {byId?.Name}");

    var expensive = await context.Products.FirstOrDefaultAsync(p => p.Price > 50000);
    Console.WriteLine($"First over 50000: {expensive?.Name}");
}

static async Task Lab6_UpdateAndDelete(AppDbContext context)
{
    var laptop = await context.Products.FirstOrDefaultAsync(p => p.Name == "Laptop");
    if (laptop != null)
    {
        laptop.Price = 70000;
        await context.SaveChangesAsync();
        Console.WriteLine($"\nLab 6: updated Laptop price to {laptop.Price}");
    }

    var riceBag = await context.Products.FirstOrDefaultAsync(p => p.Name == "Rice Bag");
    if (riceBag != null)
    {
        context.Products.Remove(riceBag);
        await context.SaveChangesAsync();
        Console.WriteLine("Lab 6: deleted Rice Bag");
    }
}

static async Task Lab7_LinqQueries(AppDbContext context)
{
    Console.WriteLine("\nLab 7: products over 1000, sorted descending by price");
    var filtered = await context.Products
        .Where(p => p.Price > 1000)
        .OrderByDescending(p => p.Price)
        .ToListAsync();
    foreach (var p in filtered)
        Console.WriteLine($"{p.Name} - {p.Price}");

    Console.WriteLine("\nLab 7: projected DTOs");
    var productDtos = await context.Products
        .Select(p => new { p.Name, p.Price })
        .ToListAsync();
    foreach (var dto in productDtos)
        Console.WriteLine($"{dto.Name} - {dto.Price}");
}
