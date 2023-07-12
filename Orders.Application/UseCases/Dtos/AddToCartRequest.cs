namespace Orders.Application.UseCases.Dtos;

public class AddToCartRequest
{
    public string CartId { get; set; }
    public string ProductSku { get; set; }
}