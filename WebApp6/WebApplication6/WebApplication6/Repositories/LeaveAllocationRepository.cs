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
        public async Task<bool> Create(LeaveAllocation entity)
        {
            await _db.LeaveAllocations.AddAsync(entity);
            return await Save();
        }
        public async Task<bool> Update(LeaveAllocation entity)
        {
            _db.LeaveAllocations.Update(entity);
            return await Save();
        }
        public async Task<bool> Delete(LeaveAllocation entity)
        {
            _db.LeaveAllocations.Remove(entity);
            return await Save();
        }

        public async Task<ICollection<LeaveAllocation>> FindAll()
        {
            return await _db.LeaveAllocations.Include(q => q.LeaveType).ToListAsync();
            // LeaveType in LeaveAllocation Controller is null
            // So we need to retrieve data from LeaveType corresponding to records in LeaveAllocation Table
            // this include operator is kinda like an inner join data with the LeaveType table
            // the problem is the details view require both data from employee and leaveType, and we use this function will only take 
            // data from Leave allocation
        }

        public async Task<LeaveAllocation> FindById(int id)
        {
            return await _db.LeaveAllocations
                .Include(q => q.LeaveType)
                .Include(q => q.Employee)
                .FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task<ICollection<LeaveAllocation>> GetEmployeeByLeaveAllocation(int id)
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
            return await _db.LeaveAllocations.AnyAsync(q => q.Id == id); // check if a table is empty
        }

        public async Task<bool> CheckAllocation(int leaveTypeId, string employeeId)
        {
            var period = DateTime.Now.Year;
            var allocation = await FindAll();
            return allocation.Where(q => q.EmployeeId == employeeId && q.LeaveTypeId == leaveTypeId && q.Period == period).Any();
        }

        public async Task<ICollection<LeaveAllocation>> GetLeaveAllocationsByEmployee(string id)
        {
            // getting allocations by employee
            var period = DateTime.Now.Year;
            var allocation = await FindAll();
            return allocation.Where(q => q.EmployeeId == id && q.Period == period)
                .ToList();
        }

        public async Task<LeaveAllocation> GetLeaveAllocationsByEmployeeAndType(string id, int leaveTypeId)
        {
            var period = DateTime.Now.Year;
            // FirstOrDefault only bring back the first record in Db
            var allocation = await FindAll();
            return allocation.FirstOrDefault(q => q.EmployeeId == id && q.Period == period && q.LeaveTypeId == leaveTypeId);
        }
    }
}
