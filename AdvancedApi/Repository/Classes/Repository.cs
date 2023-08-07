using AdvancedApi.Context;
using AdvancedApi.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AdvancedApi.Repository.Classes
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly AppDbContext _uow; 
        
        public Repository(IUnitOfWork uow)
        {
            _uow = uow as AppDbContext;
        }

        public void Add(T entity)
        {
            _uow.Add(entity);
            _uow.SaveChanges();
        }

        public IQueryable<T> GetAll() => _uow.Set<T>().AsNoTracking();
        
        public async Task<T> GetById(int id) => await _uow.Set<T>().FindAsync(id);

        public void Update(T entity)
        {
            _uow.Update(entity);
            _uow.SaveChanges();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
