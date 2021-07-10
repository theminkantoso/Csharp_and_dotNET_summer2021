using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Models
{
    public class Ticket
    {
        //[FromQuery(Name = "tid")]
        public int? TicketId { get; set; }
        //[FromRoute(Name = "pid")]
        [Required]
        public int? ProjectId { get; set; }
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        public string Description { get; set; }
        [StringLength(50)]
        public string Owner { get; set; }
        public DateTime? ReportDate { get; set; }
        //[Ticket_EnsureDueDateForTicketOwner]
        //[Ticket_EnsureDueDateInFuture]
        public DateTime? DueDate { get; set; }
        public Project Project { get; set; }
    }
}
