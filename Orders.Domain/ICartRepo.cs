namespace Orders.Domain;

public interface ICartRepo
{
    Task<Cart?> GetById(CartId cartId);
    Task SaveAsync(Cart cart);
}

