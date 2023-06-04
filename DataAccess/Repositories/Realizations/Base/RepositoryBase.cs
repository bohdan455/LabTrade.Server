using DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Realizations.Base
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly LabTradeDbContext _context;

        public RepositoryBase(LabTradeDbContext context)
        {
            _context = context;
        }
        public IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }
        public IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression);
        }
        public void Create(T entity)
        {
            //TODO Delete this
            Console.WriteLine("Start");
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
            //TODO Delete this
            Console.WriteLine("End");
        }
        public async Task CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
        public IQueryable<T>? Include(params Expression<Func<T, object>>[] expression)
        {
            IIncludableQueryable<T, object> query = null;
            if (expression.Any())
                query = _context.Set<T>().Include(expression[0]);

            for (int queryIndex = 1; queryIndex < expression.Length; queryIndex++)
            {
                query = query.Include(expression[queryIndex]);
            }

            return (IQueryable<T>)query ?? _context.Set<T>();
        }
        public async Task<T> GetFirstAsync(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().FirstAsync(expression);
        }
    }
}
