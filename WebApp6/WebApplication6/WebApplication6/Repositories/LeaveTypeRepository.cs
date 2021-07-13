using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication6.Contracts;
using WebApplication6.Data;

namespace WebApplication6.Repositories
{
    public class LeaveTypeRepository : ILeaveTypeRepository
    {
        public readonly ApplicationDbContext _db;
        public LeaveTypeRepository(ApplicationDbContext db)
        {
            this._db = db;
        }
        public bool Create(LeaveType entity)
        {
            _db.LeaveTypes.Add(entity);
            return Save();
        }
        public bool Update(LeaveType entity)
        {
            _db.LeaveTypes.Update(entity);
            return Save();
        }
        public bool Delete(LeaveType entity)
        {
            _db.LeaveTypes.Remove(entity);
            return Save();
        }
        public ICollection<LeaveType> FindAll()
        {
            return _db.LeaveTypes.ToList();
        }
        public LeaveType FindById(int id)
        {
            return _db.LeaveTypes.Find(id);
        }
        public ICollection<LeaveType> GetEmployeeByLeaveType(int id)
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
            return _db.LeaveTypes.Any(q => q.Id == id); // check if a table is empty
        }
    }
}
