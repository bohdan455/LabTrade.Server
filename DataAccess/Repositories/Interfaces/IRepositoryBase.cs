using System.Linq.Expressions;

namespace DataAccess.Repositories.Interfaces
{
    public interface IRepositoryBase<T> where T : class
    {
        void Create(T entity);
        Task CreateAsync(T entity);
        void Delete(T entity);
        IQueryable<T> GetAll();
        IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression);
        IQueryable<T>? Include(params Expression<Func<T, object>>[] expression);
        void Update(T entity);
        Task<T> GetFirstAsync(Expression<Func<T, bool>> expression);
        IQueryable<T> GetInRange(int startIndex, int endIndex, Expression<Func<T, bool>>? filter = null, Expression<Func<T, bool>>? sorting = null);
    }
}