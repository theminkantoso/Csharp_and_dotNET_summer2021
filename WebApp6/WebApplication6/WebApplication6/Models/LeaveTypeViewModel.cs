using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication6.Models
{
    public class LeaveTypeViewModel // Detail
    {
        // Only data we wanna display to user (lile DTO), some we wanna hide, some we wanna display 
        // extra and then calculate it on the fly => same to entity (Model), but not a exact match
        public int Id { get; set; }
        [Required] // also allowed in ViewModel
        public string Name { get; set; }
        [Display(Name="Date Created")]
        public DateTime? DateCreated { get; set; }
    }
}
