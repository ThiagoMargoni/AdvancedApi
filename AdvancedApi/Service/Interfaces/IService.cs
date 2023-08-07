namespace AdvancedApi.Service.Interfaces
{
    public interface IService<T> where T : class
    {
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        IQueryable<T> GetAll();
        Task<T> GetById(int id);
    }
}
