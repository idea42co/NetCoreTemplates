using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace WebApplicationBasic.Data.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        T GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void UpdateNoAttach(T entity);
        void Delete(T entity);
        void Delete(int id);
        void Delete(List<T> entities);
        IQueryable<T> Query(Expression<Func<T, bool>> filter);
        IQueryable<T> Include(IQueryable<T> query, Expression<Func<T, object>> path);
        IQueryable<T> QueryNoTracking(Expression<Func<T, bool>> filter);
    }
}