using System;
using System.Linq;
using System.Linq.Expressions;

namespace CodeChallenge.Data.CoreRepository
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        T Get(Expression<Func<T, bool>> predicate);
        IQueryable<T> Select(int skip, int take, Expression<Func<T, string>> orderBy);
    }
}