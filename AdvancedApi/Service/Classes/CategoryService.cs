using AdvancedApi.Context;
using AdvancedApi.Model;
using AdvancedApi.Repository.Interfaces;
using AdvancedApi.Service.Interfaces;

namespace AdvancedApi.Service.Classes
{
    public class CategoryService : Service<Category>, ICategoryService
    {
        public CategoryService(IUnitOfWork uow) : base(uow) { }

        public void ChangeStatus(Category category)
        {
            category.Status  = category.Status == "Active" ? "Inactive" : "Active";
            Update(category);
        }
    }
}
