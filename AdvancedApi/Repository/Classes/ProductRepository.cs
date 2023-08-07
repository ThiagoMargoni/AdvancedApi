using AdvancedApi.Context;
using AdvancedApi.Model;
using AdvancedApi.Repository.Interfaces;

namespace AdvancedApi.Repository.Classes
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(IUnitOfWork uow) : base(uow) { }
    }
}
