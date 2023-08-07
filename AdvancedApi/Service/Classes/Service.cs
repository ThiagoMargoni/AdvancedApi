using AdvancedApi.Context;
using AdvancedApi.Repository.Classes;
using AdvancedApi.Repository.Interfaces;
using AdvancedApi.Service.Interfaces;

namespace AdvancedApi.Service.Classes
{
    public class Service<T> : IService<T> where T : class
    {
        private readonly IRepository<T> _repository;

        public Service(IUnitOfWork uow)
        {
            _repository = new Repository<T>(uow);
        }
        
        public void Add(T entity) => _repository.Add(entity);

        public IQueryable<T> GetAll() => _repository.GetAll();

        public Task<T> GetById(int id) => _repository.GetById(id);

        public void Update(T entity) => _repository.Update(entity);

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
