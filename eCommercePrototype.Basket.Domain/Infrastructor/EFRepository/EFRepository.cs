using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace eCommercePrototype.Domain.Infra.EFRepository
{
    public class EFRepository<T> : IEFRepository<T> where T : class
    {
        #region Fields

        private readonly DbContext _context;
        private DbSet<T> _entities;

        #endregion

        #region Ctor

        public EFRepository(DbContext context)
        {
            this._context = context;
            this._context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

        }

        #endregion

        #region Properties

        public virtual IQueryable<T> Table
        {
            get
            {
                return Entities;
            }
        }

        public virtual IQueryable<T> TableNoTracking
        {
            get
            {
                return Entities.AsNoTracking();
            }
        }

        protected virtual DbSet<T> Entities
        {
            get
            {
                if (_entities == null)
                    _entities = _context.Set<T>();
                return _entities;
            }
        }

        #endregion

        #region Methods

        public virtual T Add(T entity)
        {
            if (entity == null)
                return null;

            Entities.Add(entity);
            _context.SaveChanges();
            if (entity != null)
                if (_context.Entry(entity).State != EntityState.Detached)
                    _context.Entry(entity).State = EntityState.Detached;
            return entity;
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            try
            {
                if (entity == null)
                    return null;

                await Entities.AddAsync(entity);
                await _context.SaveChangesAsync();
                if (entity != null)
                    if (_context.Entry(entity).State != EntityState.Detached)
                        _context.Entry(entity).State = EntityState.Detached;

                return entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public virtual async Task<int> AddRangeAsync(List<T> entities)
        {
            try
            {
                Entities.AddRange(entities);

                var recordCount = await _context.SaveChangesAsync();

                return recordCount;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public virtual T Update(T entity)
        {
            if (entity == null)
                return null;

            Entities.Update(entity);
            _context.SaveChanges();
            if (entity != null)
                if (_context.Entry(entity).State != EntityState.Detached)
                    _context.Entry(entity).State = EntityState.Detached;
            return entity;
        }

        public virtual async Task<int> UpdateRange(List<T> entities)
        {
            try
            {
                if (entities != null && entities.Count() == 0)
                    return 0;

                Entities.UpdateRange(entities);
                var recordCount = _context.SaveChanges();

                return recordCount;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual async Task<T> UpdateAsync(T entity)
        {
            try
            {
                if (entity == null)
                    return null;

                _context.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                if (entity != null)
                    if (_context.Entry(entity).State != EntityState.Detached)
                        _context.Entry(entity).State = EntityState.Detached;
                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual void Delete(T entity)
        {
            if (entity == null)
                return;
            Entities.Remove(entity);

            _context.SaveChanges();
        }

        public virtual async Task<int> DeleteRange(Expression<Func<T, bool>> predicate)
        {
            var recordCount = 0;
            var records = Entities.Where(predicate).ToList();
            try
            {
                if (records.Count > 0)
                    Entities.RemoveRange(records);

                recordCount = await _context.SaveChangesAsync();

                return recordCount;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual T Get(Expression<Func<T, bool>> match, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> queryable = Entities;
            foreach (Expression<Func<T, object>> includeProperty in includeProperties)
            {
                queryable = queryable.Include(includeProperty);
            }
            return queryable.FirstOrDefault(match);
        }

        public virtual async Task<T> GetAsync(Expression<Func<T, bool>> match, params Expression<Func<T, object>>[] includeProperties)
        {
            try
            {
                IQueryable<T> queryable = TableNoTracking;
                foreach (Expression<Func<T, object>> includeProperty in includeProperties)
                {
                    queryable = queryable.Include(includeProperty);
                }
                return queryable.FirstOrDefault(match);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> queryable = TableNoTracking;
            foreach (Expression<Func<T, object>> includeProperty in includeProperties)
            {
                queryable = queryable.Include(includeProperty);
            }

            return queryable;
        }

        public virtual List<T> GetAll(Expression<Func<T, bool>> match, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> queryable = TableNoTracking;
            foreach (Expression<Func<T, object>> includeProperty in includeProperties)
            {
                queryable = queryable.Include(includeProperty);
            }
            return queryable.Where(match).ToList();
        }

        public virtual async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> match, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> queryable = TableNoTracking;
            foreach (Expression<Func<T, object>> includeProperty in includeProperties)
            {
                queryable = queryable.Include(includeProperty);
            }
            return await queryable.Where(match).ToListAsync();
        }


        public virtual int Count()
        {
            return Entities.Count();
        }

        public virtual async Task<int> CountAsync()
        {
            return await Entities.CountAsync();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
