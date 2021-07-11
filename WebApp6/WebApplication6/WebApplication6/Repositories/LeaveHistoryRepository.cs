using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication6.Contracts;
using WebApplication6.Data;

namespace WebApplication6.Repositories
{
    public class LeaveHistoryRepository : ILeaveHistoryRepository
    {
        public readonly ApplicationDbContext _db;
        public LeaveHistoryRepository(ApplicationDbContext db)
        {
            this._db = db;
        }
        public bool Create(LeaveHistory entity)
        {
            _db.LeaveHistories.Add(entity);
            return Save();
        }
        public bool Update(LeaveHistory entity)
        {
            _db.LeaveHistories.Update(entity);
            return Save();
        }
        public bool Delete(LeaveHistory entity)
        {
            _db.LeaveHistories.Remove(entity);
            return Save();
        }

        public ICollection<LeaveHistory> FindAll()
        {
            return _db.LeaveHistories.ToList();
        }

        public LeaveHistory FindById(int id)
        {
            return _db.LeaveHistories.Find(id);
        }

        public ICollection<LeaveHistory> GetEmployeeByLeaveHistory(int id)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            // interger if how many record edited, so it will >= 1
            return _db.SaveChanges() > 0;
        }
    }
}
