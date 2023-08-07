using AdvancedApi.Context;
using AdvancedApi.Model;
using AdvancedApi.Service.Interfaces;

namespace AdvancedApi.Service.Classes
{
    public class ProductService : Service<Product>, IProductService
    {
        public ProductService(IUnitOfWork uow) : base(uow) { }

        public void ChangeStatus(Product product)
        {
            product.Status = product.Status == "Active" ? "Inactive" : "Active";
            Update(product);
        }
    }
}
