using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication6.Data;

namespace WebApplication6.Contracts
{
    public interface ILeaveTypeRepository : IRepositoryBase<LeaveType>
    {
        ICollection<LeaveType> GetEmployeeByLeaveType(int id);
    }
}
