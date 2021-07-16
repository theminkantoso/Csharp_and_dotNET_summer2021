using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication6.Models
{
    public class LeaveTypeViewModel 
    {
        // Only data we wanna display to user (lile DTO), some we wanna hide, some we wanna display 
        // extra and then calculate it on the fly => same to entity (Model), but not a exact match
        public int Id { get; set; }
        [Required] // also allowed in ViewModel
        public string Name { get; set; }
        [Required]
        [Display(Name = "Default number of days")]
        [Range(1,25, ErrorMessage ="Please enter a valid number")]
        public int DefaultDays { get; set; }
        [Display(Name="Date Created")]
        public DateTime? DateCreated { get; set; }
    }
}
