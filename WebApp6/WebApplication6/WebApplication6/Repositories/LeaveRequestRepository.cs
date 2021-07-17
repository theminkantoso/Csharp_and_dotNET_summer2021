using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication6.Contracts;
using WebApplication6.Data;

namespace WebApplication6.Repositories
{
    public class LeaveRequestRepository : ILeaveRequestRepository
    {
        public readonly ApplicationDbContext _db;
        public LeaveRequestRepository(ApplicationDbContext db)
        {
            this._db = db;
        }
        public bool Create(LeaveRequest entity)
        {
            _db.LeaveRequests.Add(entity);
            return Save();
        }
        public bool Update(LeaveRequest entity)
        {
            _db.LeaveRequests.Update(entity);
            return Save();
        }
        public bool Delete(LeaveRequest entity)
        {
            _db.LeaveRequests.Remove(entity);
            return Save();
        }

        public ICollection<LeaveRequest> FindAll()
        {
            return _db.LeaveRequests.Include(q => q.RequestingEmployee)
                .Include(q => q.ApprovedBy)
                .Include(q => q.LeaveType)
                .ToList();
        }

        public LeaveRequest FindById(int id)
        {
            return _db.LeaveRequests.Include(q => q.RequestingEmployee)
                .Include(q => q.ApprovedBy)
                .Include(q => q.LeaveType)
                .ToList()
                .FirstOrDefault(q => q.Id == id);
        }

        public ICollection<LeaveRequest> GetEmployeeByLeaveRequest(int id)
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
            return _db.LeaveRequests.Any(q => q.Id == id); // check if a table is empty
        }

        public ICollection<LeaveRequest> GetLeaveRequestsByEmployee(string employeeid)
        {
            var leaveRequests = FindAll()
                .Where(q => q.RequestingEmployeeId == employeeid)
                .ToList();
            return leaveRequests;
        }
    }
}
