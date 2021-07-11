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
        ICollection<T> FindAll();
        T FindById(int id);
        bool Create(T entity);
        bool Update(T entity);
        bool Delete(T entity);
        bool Save();
    }
}
