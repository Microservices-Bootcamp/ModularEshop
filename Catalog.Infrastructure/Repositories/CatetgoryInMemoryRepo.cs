using Catalog.Domain.Contracts;
using Catalog.Domain.Entities;

namespace Catalog.Infrastructure.Repositories
{
    public class CatetgoryInMemoryRepo : ICategoryRepository
    {
        private static List<Category> _categories = new List<Category>();

        public async Task Add(Category category)
        {
            _categories.Add(category);
        }

        public bool CategoryNameIsExist(string name)
        {
            return _categories.Any(x => x.Name == name);
        }
    }
}