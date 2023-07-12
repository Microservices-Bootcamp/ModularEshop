using System.ComponentModel.DataAnnotations;

namespace Catalog.Application.Dtos;

public class CreateCategoryRequest
{
    [Required]
    public string CategoryName { get; set; }
}