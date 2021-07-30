using System;
using System.Collections.Generic;
using System.Linq;
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
}
