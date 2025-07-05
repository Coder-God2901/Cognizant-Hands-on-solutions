namespace RetailInventorySystem.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Stock { get; set; }

    // Foreign Key
    public int CategoryId { get; set; }
    public Category? Category { get; set; }
}
