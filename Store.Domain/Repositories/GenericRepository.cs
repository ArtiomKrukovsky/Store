using Store.Domain.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

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

        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet.AsNoTracking().ToList();
        }
    }
}
