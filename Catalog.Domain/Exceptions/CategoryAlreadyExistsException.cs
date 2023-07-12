namespace Catalog.Domain.Exceptions
{
    [Serializable]
    public class CategoryAlreadyExistsException : Exception
    {
        public CategoryAlreadyExistsException(string categoryName) : base($"Category with name {categoryName} is already exist!")
        {
        }
    }
}