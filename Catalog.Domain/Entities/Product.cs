namespace Catalog.Domain.Entities;

public class Product
{
    private List<DomainEvent> _domainEvents = new List<DomainEvent>();
    public Sku Sku { get; private set; }
    public string Name { get; private set; }
    public Guid CategoryId { get; private set; }
    public string Description { get; private set; }
    public decimal CostPrice { get; private set; }
    public decimal SellingPrice { get; private set; }
    public int Count { get; private set; }
    public bool IsAvailable { get; private set; }

    private Product(Sku sku, string name, Guid categoryId, string description, decimal costPrice, decimal sellingPrice,
        int count, bool isAvailable)
    {
        Sku = sku;
        Name = name;
        CategoryId = categoryId;
        Description = description;
        CostPrice = costPrice;
        SellingPrice = sellingPrice;
        Count = count;
        IsAvailable = isAvailable;
    }


    public IReadOnlyCollection<DomainEvent> GetOccuredEvents()
    {
        return _domainEvents.AsReadOnly();
    }

    public static Product CreateNew(Sku sku, string name, Guid categoryId, string description, decimal costPrice,
        decimal sellingPrice, int count)
    {
        // requirement to set available false when we create new product
        var product = new Product(sku,
            name,
            categoryId,
            description,
            costPrice,
            sellingPrice,
            count,
            false
        );
        product._domainEvents.Add(new ProductCreated(sku, categoryId));
        return product;
    }

    public void ChangeCategory(Guid categoryId)
    {
        // any validation
        this.CategoryId = categoryId;
    }
}

public interface DomainEvent
{
}

public record ProductCreated(Sku sku, Guid CategoryId) : DomainEvent;

public record Sku
{
    public string _value { get; private set; }

    public Sku(string value)
    {
        if (value.Length > 8)
        {
            throw new SkuIsInCorrectException();
        }

        _value = value;
    }
}

public class SkuIsInCorrectException : Exception
{
}