using System.ComponentModel.DataAnnotations;

namespace Catalog.Application.Dtos;

public class CreateProductRequest
{
    [Required] [MaxLength(8)] public string Sku { get; set; }
    [Required] [MinLength(3)] public string Name { get; set; }
    [Required] public Guid CategoryId { get; set; }
    [Required] [MinLength(3)] public string Description { get; set; }
    public decimal CostPrice { get; set; }
    public decimal SellingPrice { get; set; }
    [Range(0, 1000000000)] public int Count { get; set; }
    public bool IsAvailable { get; set; }
}