using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebApplication6.Contracts;
using WebApplication6.Data;

namespace WebApplication6.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _db;
        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _db = _context.Set<T>();
        }
        public async Task Create(T entity)
        {
            await _db.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _db.Remove(entity);
        }

        public async Task<T> Find(Expression<Func<T, bool>> expression, Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null)
        {
            IQueryable<T> query = _db;
            if(includes != null)
            {
                //foreach (var table in includes)
                //{
                //    query = query.Include(table);
                //}
                query = includes(query);
            }
            return await query.FirstOrDefaultAsync(expression);
        }

        public async Task<IList<T>> FindAll(Expression<Func<T, bool>> expression = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null)
        {
            IQueryable<T> query = _db;
            if (expression != null)
            {
                query = query.Where(expression);
            }
            if (includes != null)
            {
                query = includes(query);
                //foreach (var table in includes)
                //{
                //    query = query.Include(table);
                //}
            }
            if (orderBy != null)
            {
                query = orderBy(query);
                //foreach (var table in includes)
                //{
                //    query = orderBy(query);
                //}
            }
            return await query.ToListAsync();
        }

        public async Task<bool> isExists(Expression<Func<T, bool>> expression = null)
        {
            IQueryable<T> query = _db; //database object, if toList then no longer dB object
            return await query.AnyAsync(expression); /*(expression: query => query.Id=10)*/        }

        //public Task<bool> Save()
        //{
        //    throw new NotImplementedException();
        //}

        public void Update(T entity)
        {
            _db.Update(entity);
        }
    }
}
