using AdvancedApi.Model;

namespace AdvancedApi.Service.Interfaces
{
    public interface IProductService : IService<Product>
    {
        void ChangeStatus(Product product);
    }
}
