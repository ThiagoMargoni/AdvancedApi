using AdvancedApi.Model;

namespace AdvancedApi.Service.Interfaces
{
    public interface ICategoryService : IService<Category>
    {
        void ChangeStatus(Category category);
    }
}
