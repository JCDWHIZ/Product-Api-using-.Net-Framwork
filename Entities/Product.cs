using System;

namespace WebApplication1.Entities;

public class Product
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required decimal CurrentPrice { get; set; }
    public required decimal OldPrice { get; set; }
    public required string Description { get; set; }
    public required string BackdropUrl {get; set;}
    public required decimal Rating { get; set; }
    public int CategoryId { get; set; }
    public Category? Category { get; set; } 
}
