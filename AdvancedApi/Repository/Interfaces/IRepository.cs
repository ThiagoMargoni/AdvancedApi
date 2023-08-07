namespace AdvancedApi.Repository.Interfaces
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        IQueryable<T> GetAll();
        Task<T> GetById(int id);
    }
}
