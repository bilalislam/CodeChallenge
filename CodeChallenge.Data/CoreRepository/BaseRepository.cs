using System;
using System.Data.Entity;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using System.Linq.Expressions;
using CodeChallenge.Data.UoW;

namespace CodeChallenge.Data.CoreRepository
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        protected DbContext Context => UnitOfWork.Current.Context;

        public void Add(T entity)
        {
            this.Context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            this.Context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            this.Context.Entry(entity).State = EntityState.Deleted;
            this.Context.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> predicate)
        {
            return this.Context.Set<T>().Where(predicate).FirstOrDefault();
        }

        public IQueryable<T> Select(int skip, int take, Expression<Func<T, string>> orderBy)
        {
            return this.Context.Set<T>().OrderByDescending(orderBy).Skip(skip).Take(take);
        }
    }
}
