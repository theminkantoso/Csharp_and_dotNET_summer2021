using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApplication5.Models;

namespace WebApplication5.ModelValidations
{
    public class Ticket_EnsureDueDateForTicketOwner : ValidationAttribute
    {
        // override the IsValid method, then use that attribute in the entity
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var ticket = validationContext.ObjectInstance as Ticket;
            if (ticket != null && !string.IsNullOrWhiteSpace(ticket.Owner))
            {
                if (!ticket.DueDate.HasValue)
                {
                    return new ValidationResult("Due date is required when the ticket has an owner");
                }
            }
            return ValidationResult.Success;
        }
    }
}
