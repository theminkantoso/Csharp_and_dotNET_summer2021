using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication6.Contracts;
using WebApplication6.Data;

namespace WebApplication6.Repositories
{
    public class LeaveAllocationRepository : ILeaveAllocationRepository
    {
        public readonly ApplicationDbContext _db;
        public LeaveAllocationRepository(ApplicationDbContext db)
        {
            this._db = db;
        }
        public bool Create(LeaveAllocation entity)
        {
            _db.LeaveAllocations.Add(entity);
            return Save();
        }
        public bool Update(LeaveAllocation entity)
        {
            _db.LeaveAllocations.Update(entity);
            return Save();
        }
        public bool Delete(LeaveAllocation entity)
        {
            _db.LeaveAllocations.Remove(entity);
            return Save();
        }

        public ICollection<LeaveAllocation> FindAll()
        {
            return _db.LeaveAllocations.ToList();
        }

        public LeaveAllocation FindById(int id)
        {
            return _db.LeaveAllocations.Find(id);
        }

        public ICollection<LeaveAllocation> GetEmployeeByLeaveAllocation(int id)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            // interger if how many record edited, so it will >= 1
            return _db.SaveChanges() > 0;
        }

        public bool isExists(int id)
        {
            return _db.LeaveAllocations.Any(q => q.Id == id); // check if a table is empty
        }
    }
}
