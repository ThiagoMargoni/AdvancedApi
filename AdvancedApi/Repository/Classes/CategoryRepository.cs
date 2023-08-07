using AdvancedApi.Context;
using AdvancedApi.Model;
using AdvancedApi.Repository.Interfaces;

namespace AdvancedApi.Repository.Classes
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(IUnitOfWork uow) : base(uow) { }
    }
}
