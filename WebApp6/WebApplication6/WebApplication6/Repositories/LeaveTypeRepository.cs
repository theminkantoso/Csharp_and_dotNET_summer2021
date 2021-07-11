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
            throw new NotImplementedException();
        }

        public bool Delete(LeaveType entity)
        {
            throw new NotImplementedException();
        }

        public ICollection<LeaveType> FindAll()
        {
            throw new NotImplementedException();
        }

        public LeaveType FindById(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<LeaveType> GetEmployeeByLeaveType(int id)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool Update(LeaveType entity)
        {
            throw new NotImplementedException();
        }
    }
}
