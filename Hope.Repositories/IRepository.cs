using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hope.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);

        bool Update(TEntity entity);

        bool Delete(TEntity entity);

        IQueryable<TEntity> GetAll(); // Out Memory Query

        // IEnumerable<TEntity> GetAll2(); // In Memory Query

        TEntity GetById(int id);

        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> expression, params Expression<Func<TEntity, object>>[] includes);
    }
}
