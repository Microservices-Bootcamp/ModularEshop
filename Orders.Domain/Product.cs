namespace Orders.Domain;

public record Product
(
    string Sku,
    string Name,
    decimal Price,
    int Count,
    bool IsAvailable
)
{
    public bool IsNotAvailable(int count)
    {
        return !IsAvailable || Count < count;
    }
}