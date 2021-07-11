using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication6.Data;

namespace WebApplication6.Contracts
{
    interface ILeaveAllocationRepository : IRepositoryBase<LeaveAllocation>
    {
        ICollection<LeaveAllocation> GetEmployeeByLeaveAllocation(int id);
    }
}
