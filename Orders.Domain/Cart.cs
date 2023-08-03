namespace Orders.Domain;

public class Cart
{
    private List<CartItem> _items = new();
    public CartId Id;
    public Guid UserId { get; private set; }

    private Cart(Guid userId, CartId id)
    {
        UserId = userId;
        Id = id;
    }

    public static Cart NewCart(Guid userId)
    {
        return new Cart(userId, new CartId(Guid.NewGuid()));
    }

    public void AddToCart(Product product, int qty)
    {
        var item = new CartItem(product, qty);
        _items.RemoveAll(x => x.Product == product);
        _items.Add(item);
    }
}

internal record CartItem(Product Product, int Qty);

public record CartId(Guid value);