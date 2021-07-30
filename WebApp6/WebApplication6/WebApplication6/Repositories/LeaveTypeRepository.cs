using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication6.Contracts;
using WebApplication6.Data;
using Microsoft.EntityFrameworkCore;

namespace WebApplication6.Repositories
{
    public class LeaveTypeRepository : ILeaveTypeRepository
    {
        public readonly ApplicationDbContext _db;
        public LeaveTypeRepository(ApplicationDbContext db)
        {
            this._db = db;
        }
        public async Task<bool> Create(LeaveType entity)
        {
            await _db.LeaveTypes.AddAsync(entity);
            return await Save ();
        }
        public async Task<bool> Update(LeaveType entity)
        {
            _db.LeaveTypes.Update(entity);
            return await Save();
        }
        public async Task<bool> Delete(LeaveType entity)
        {
            _db.LeaveTypes.Remove(entity);
            return await Save();
        }
        public async Task<ICollection<LeaveType>> FindAll()
        {
            return await _db.LeaveTypes.ToListAsync();
        }
        public async Task<LeaveType> FindById(int id)
        {
            return await _db.LeaveTypes.FindAsync(id);
        }
        public ICollection<LeaveType> GetEmployeeByLeaveType(int id)
        {
            throw new NotImplementedException();
        }
        public async Task<bool> Save()
        {
            // interger if how many record edited, so it will >= 1
            return await _db.SaveChangesAsync() > 0;
        }

        public async Task<bool> isExists(int id)
        {
            return await _db.LeaveTypes.AnyAsync(q => q.Id == id); // check if a table is empty
        }
    }
}
