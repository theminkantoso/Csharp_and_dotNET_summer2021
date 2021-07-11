using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication6.Data;

namespace WebApplication6.Contracts
{
    interface ILeaveHistoryRepository : IRepositoryBase<LeaveHistory>
    {
        ICollection<LeaveHistory> GetEmployeeByLeaveHistory(int id);
    }
}
