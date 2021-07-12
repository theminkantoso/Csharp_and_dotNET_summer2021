using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication6.Models
{
    public class DetailsLeaveTypeViewModel // Detail
    {
        // Only data we wanna display to user (lile DTO), some we wanna hide, some we wanna display 
        // extra and then calculate it on the fly => same to entity (Model), but not a exact match
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
    }
    public class CreateLeaveTypeViewModel
    {
        // Only data we wanna display to user (lile DTO), some we wanna hide, some we wanna display 
        // extra and then calculate it on the fly => same to entity (Model), but not a exact match
        [Required] // also allowed in ViewModel
        public string Name { get; set; }
    }
}
