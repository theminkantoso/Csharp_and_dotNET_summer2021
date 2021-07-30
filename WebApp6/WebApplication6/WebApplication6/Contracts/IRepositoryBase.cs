using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WebApplication6.Contracts
{
    public interface IRepositoryBase<T> where T : class
    // generic, any class can be performed
    // apply for all tables
    {
        // accept all type of array passed in
        Task<ICollection<T>> FindAll();
        Task<T> FindById(int id);
        Task<bool> isExists(int id);
        Task<bool> Create(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(T entity);
        Task<bool> Save();
    }

    //public interface IGenericRepository<T> where T : class
    //{
        // q(T) => q.Id == 20 (bool)
        //Task<IList<T>> FindAll(
        //    Expression<Func<T, bool>> expression = null, // q(T) => q.Id == 20 (bool)
        //    Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, // q => q.OrderBy(q => q.Id)
        //    List<string> includes = null
        //    );
        //Task<T> Find(Expression<Func<T, bool>> expression = null, List<string> includes = null);
        //Task<bool> isExists(Expression<Func<T, bool>> expression = null);
        //Task Create(T entity);
        //void Update(T entity);
        //void Delete(T entity);
        //Task<bool> Save();
    //}
}
