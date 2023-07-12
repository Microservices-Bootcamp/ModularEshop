using Catalog.Domain.Entities;

namespace Catalog.Domain.Contracts
{
	public interface ICategoryRepository
	{
		public bool CategoryNameIsExist(string name);
		public Task Add(Category category);
	}
}

