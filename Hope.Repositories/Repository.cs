using Hope.DomainEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hope.Repositories
{
    public class Repository<TEntity> :IRepository<TEntity> where TEntity : class
    {
        private DbSet<TEntity> dbSet;
        private readonly HopeBankManagementSystemContext context;


        public Repository()
        {
            this.context = new HopeBankManagementSystemContext();
            this.dbSet = context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            dbSet.Add(entity);
            context.SaveChanges();
        }

        public bool Update(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.Update(entity);
            context.SaveChanges();
            return true;
        }

        public bool Delete (TEntity entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            dbSet.Remove(entity);
            context.SaveChanges();
            return true;
        }

        public IQueryable<TEntity> GetAll()
        {
            return dbSet.AsQueryable();
        }

        public TEntity GetById(int id)
        {
           return context.Set<TEntity>().Find(id);
        }

        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> expression, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = dbSet;

            foreach (var item in includes)
            {
                query = query.Include(item);
            }
            return query.Where(expression);
        }
    }
}
