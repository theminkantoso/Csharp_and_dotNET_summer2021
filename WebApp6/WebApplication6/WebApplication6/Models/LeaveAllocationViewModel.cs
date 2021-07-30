using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication6.Models
{
    public class LeaveAllocationViewModel
    {
        // There is one problem here
        // We can import from Data, but it means different layers are affecting each other
        // Remember the purpose of layered architectur, we want everything work independently
        // So here we have to create new ViewModel for Employee and LeaveType
        public int Id { get; set; }
        public int NumberOfDays { get; set; }
        public DateTime DateCreated { get; set; }
        public int Period { get; set; }
        public EmployeeViewModel Employee { get; set; }
        public string EmployeeId { get; set; }
        public LeaveTypeViewModel LeaveType { get; set; }
        public int LeaveTypeId { get; set; }
        // list of employees and leave types, two attribute above only represents a single one, we need a list
        // using IEnumarable for more flexible
        // but this change is no longer in effect
        //public IEnumerable<SelectListItem> Employees { get; set; }
        //public IEnumerable<SelectListItem> LeaveTypes { get; set; }
    }
    public class CreateLeaveAllocationViewModel
    {
        public int NumberUpdated { get; set; }
        public List<LeaveTypeViewModel> LeaveTypes { get; set; }
    }
    public class EditLeaveAllocationViewModel
    {
        public int NumberOfDays { get; set; }
        public LeaveTypeViewModel LeaveType { get; set; }
        public int Id { get; set; }
        public EmployeeViewModel Employee { get; set; }
        public string EmployeeId { get; set; }
    }
    public class ViewAllocationViewModel
    {
        // We dont want any dataclass on viewmodel
        public EmployeeViewModel Employee { get; set; }
        public string EmployeeId { get; set; }
        public List<LeaveAllocationViewModel> LeaveAllocations { get; set; }
    }
}
