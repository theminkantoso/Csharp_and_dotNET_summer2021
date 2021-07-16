using Microsoft.EntityFrameworkCore;
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
            return _db.LeaveAllocations.Include(q => q.LeaveType).ToList();
            // LeaveType in LeaveAllocation Controller is null
            // So we need to retrieve data from LeaveType corresponding to records in LeaveAllocation Table
            // this include operator is kinda like an inner join data with the LeaveType table
            // the problem is the details view require both data from employee and leaveType, and we use this function will only take 
            // data from Leave allocation
        }

        public LeaveAllocation FindById(int id)
        {
            return _db.LeaveAllocations
                .Include(q => q.LeaveType)
                .Include(q => q.Employee)
                .FirstOrDefault(q => q.Id == id);
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

        public bool CheckAllocation(int leaveTypeId, string employeeId)
        {
            var period = DateTime.Now.Year;
            return FindAll().Where(q => q.EmployeeId == employeeId && q.LeaveTypeId == leaveTypeId && q.Period == period).Any();
        }

        public ICollection<LeaveAllocation> GetLeaveAllocationsByEmployee(string id)
        {
            // getting allocations by employee
            var period = DateTime.Now.Year;
            return FindAll().Where(q => q.EmployeeId == id && q.Period == period).ToList();
        }
    }
}
