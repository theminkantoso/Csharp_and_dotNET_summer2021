using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebApplication6.Models;

namespace WebApplication6.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<LeaveHistory> LeaveHistories { get; set; }
        public DbSet<LeaveType> LeaveTypes { get; set; }
        public DbSet<LeaveAllocation> LeaveAllocations { get; set; }
        public DbSet<WebApplication6.Models.LeaveTypeViewModel> DetailsLeaveTypeViewModel { get; set; }
        public DbSet<WebApplication6.Models.EmployeeViewModel> EmployeeViewModel { get; set; }
        public DbSet<WebApplication6.Models.LeaveAllocationViewModel> LeaveAllocationViewModel { get; set; }
        public DbSet<WebApplication6.Models.EditLeaveAllocationViewModel> EditLeaveAllocationViewModel { get; set; }
    }
}
