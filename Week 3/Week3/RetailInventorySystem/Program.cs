using Microsoft.EntityFrameworkCore;
using RetailInventorySystem;
using RetailInventorySystem.Models;
'['
using var context = new AppDbContext();

// Clear old data
await context.Database.EnsureDeletedAsync();
await context.Database.EnsureCreatedAsync();

// Add categories
var electronics = new Category { Name = "Electronics" };
var groceries = new Category { Name = "Groceries" };

await context.Categories.AddRangeAsync(electronics, groceries);
await context.SaveChangesAsync();

// Add products
var product1 = new Product { Name = "Smartphone", Stock = 25, CategoryId = electronics.Id };
var product2 = new Product { Name = "Rice", Stock = 100, CategoryId = groceries.Id };

await context.Products.AddRangeAsync(product1, product2);
await context.SaveChangesAsync();

Console.WriteLine("✅ Data seeded successfully!");

// All products
var allProducts = await context.Products.Include(p => p.Category).ToListAsync();
Console.WriteLine("📦 All Products:");
foreach (var p in allProducts)
{
    Console.WriteLine($"- {p.Name} ({p.Category?.Name}) - Stock: {p.Stock}");
}

// Find by ID
var productById = await context.Products.FindAsync(1);
Console.WriteLine($"\n🔍 Found by ID 1: {productById?.Name}");

// FirstOrDefault with condition
var rice = await context.Products.FirstOrDefaultAsync(p => p.Name.Contains("Rice"));
Console.WriteLine($"\n🍚 First matching 'Rice': {rice?.Name} with Stock: {rice?.Stock}");
