using Orders.Domain;

namespace Orders.Infrastructure;

public class CartRepoInMemory: ICartRepo
{
    private List<Cart> _carts = new List<Cart>();
    public async Task<Cart?> GetById(CartId cartId)
    {
        return _carts.SingleOrDefault(x => x.Id == cartId);
    }

    public Task SaveAsync(Cart cart)
    {
        _carts.Add(cart);
        return Task.CompletedTask;
    }
}