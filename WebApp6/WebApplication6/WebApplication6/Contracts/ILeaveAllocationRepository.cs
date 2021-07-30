using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication6.Data;

namespace WebApplication6.Contracts
{
    public interface ILeaveAllocationRepository : IRepositoryBase<LeaveAllocation>
    {
        Task<ICollection<LeaveAllocation>> GetEmployeeByLeaveAllocation(int id);
        Task<bool> CheckAllocation(int leaveTypeId, string employeeId);
        Task<ICollection<LeaveAllocation>> GetLeaveAllocationsByEmployee(string id);
        Task<LeaveAllocation> GetLeaveAllocationsByEmployeeAndType(string id, int leaveTypeId);
    }
}
