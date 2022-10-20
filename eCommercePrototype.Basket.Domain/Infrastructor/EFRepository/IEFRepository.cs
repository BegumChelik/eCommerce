using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace eCommercePrototype.Domain.Infra.EFRepository
{
    public interface IEFRepository<T> where T : class
    {
        T Get(Expression<Func<T, bool>> match, params Expression<Func<T, object>>[] includeProperties);
        Task<T> GetAsync(Expression<Func<T, bool>> match, params Expression<Func<T, object>>[] includeProperties);
        List<T> GetAll(Expression<Func<T, bool>> match, params Expression<Func<T, object>>[] includeProperties);
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> match, params Expression<Func<T, object>>[] includeProperties);
        IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties);
      
        T Add(T entity);
        Task<T> AddAsync(T entity);
        Task<int> AddRangeAsync(List<T> entities);
        void Delete(T entity);
        Task<int> DeleteRange(Expression<Func<T, bool>> predicate);
        T Update(T entity);
        Task<T> UpdateAsync(T entity);
        Task<int> UpdateRange(List<T> entities);
        int Count();
        Task<int> CountAsync();
        IQueryable<T> Table { get; }
        IQueryable<T> TableNoTracking { get; }
        void Dispose();
    }
}
