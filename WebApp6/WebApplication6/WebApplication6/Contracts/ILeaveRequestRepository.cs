using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication6.Data;

namespace WebApplication6.Contracts
{
    public interface ILeaveRequestRepository : IRepositoryBase<LeaveRequest>
    {
        ICollection<LeaveRequest> GetEmployeeByLeaveRequest(int id);
        ICollection<LeaveRequest> GetLeaveRequestsByEmployee(string employeeid);
    }
}
