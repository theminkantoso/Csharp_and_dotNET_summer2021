using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication6.Models
{
    public class LeaveHistoryViewModel
    {
        public int Id { get; set; }
        public EmployeeViewModel RequestingEmployee { get; set; } // employee who requested to leave
        [Required]
        public string RequestingEmployeeId { get; set; } // Employee class inheriting from identity user, so it has an id as an inheritance
        [Required]
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DetailsLeaveTypeViewModel LeaveType { get; set; }
        public int LeaveTypeId { get; set; }
        public IEnumerable<SelectListItem> LeaveTypes { get; set; }
        public DateTime DateRequested { get; set; }
        public DateTime DateActioned { get; set; } // kinda like judgement day
        public bool? Approved { get; set; } //yes - no or pending
        public EmployeeViewModel ApprovedBy { get; set; }
        public string ApprovedById { get; set; }
    }
}
