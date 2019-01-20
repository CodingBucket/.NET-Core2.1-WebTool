using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace WebTool.Core.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Find(int id);

        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate);

        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}
