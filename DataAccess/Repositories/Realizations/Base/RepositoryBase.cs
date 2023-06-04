using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Realizations.Base
{
    public abstract class RepositoryBase<T> where T : class
    {
        private readonly LabTradeDbContext _context;

        public RepositoryBase(LabTradeDbContext context)
        {
            _context = context;
        }
        public IQueryable<T> GetAll()
        {
            return _context.Set<T>().AsNoTracking();
        }
        public IQueryable<T> GetByCondition(Expression<Func<T,bool>> expression)
        {
            return _context.Set<T>().Where(expression).AsNoTracking();
        }
        public void Create(T entity)
        {
            _context.Set<T>().Add(entity);
        }
        public async Task CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }
        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
        public IQueryable<T>? Include(params Expression<Func<T,object>>[] expression)
        {
            IIncludableQueryable<T,object> query = null;
            if(expression.Any())
                query = _context.Set<T>().Include(expression[0]);

            for (int queryIndex = 1; queryIndex < expression.Length; queryIndex++)
            {
                query = query.Include(expression[queryIndex]);
            }

            return (IQueryable<T>)query ?? _context.Set<T>();
        }
    }
}
