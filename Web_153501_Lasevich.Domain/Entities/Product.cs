

namespace Web_153501_Lasevich.Domain.Entities;



public class Product
{
    public int? Id { get; set; }
    public string? Name { get; set; }
    public string? Manufacturer { get; set; }
    public string? Description { get; set; }
    public double? Price { get; set; }
    public int? CategoryId { get; set; }
    public Category? Category { get; set; }
    public string? ImagePath { get; set; }
    public string? ImageMimeType { get; set; }
}
