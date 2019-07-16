using Store.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Store.Domain.Repositories
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private StoreContext context;
        private DbSet<TEntity> _dbSet;

        public GenericRepository(StoreContext context)
        {
            this.context = context;
            _dbSet = context.Set<TEntity>();
        }

        public void Create(TEntity Entity)
        {
            _dbSet.Add(Entity);
        }

        public void Delete(int id)
        {
            var entity = _dbSet.Find(id);
            if (entity!=null)
            {
                _dbSet.Remove(entity);
            }
        }

        public void Edit(TEntity Entity)
        {
            context.Entry(Entity).State = EntityState.Modified;
        }

        public TEntity Get(int id)
        {
            return _dbSet.Find(id);
        }

        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet.AsNoTracking().ToList();
        }
    }
}
