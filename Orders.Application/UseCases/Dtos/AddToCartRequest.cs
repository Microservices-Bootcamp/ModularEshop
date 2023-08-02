namespace Orders.Application.UseCases.Dtos;

public class AddToCartRequest
{
    public string CartId { get; set; }
    public string ProductSku { get; set; }
    public int ProductQuantity { get; set; }
    public Guid UserId { get; set; }
}