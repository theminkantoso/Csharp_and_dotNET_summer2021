using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication5.Models;

namespace WebApplication5.Filters
{
    public class Ticket_ValidateDatesActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            var ticket = context.ActionArguments["ticket"] as Ticket;
            if (ticket != null && !string.IsNullOrWhiteSpace(ticket.Owner))
            {
                bool isValid = true;
                if (ticket.EnteredDate.HasValue == false)
                {
                    // short circuiting
                    // using modelstate data construct
                    // using model state: what is the key? and what is the error message
                    // validation we dont have to specify the key because we apply directly on the field
                    // but here we apply on the action, and the action doesnt know anything about field inside the model
                    context.ModelState.AddModelError("EnteredDate", "EnteredDate is required.");
                    isValid = false;
                }
                if (ticket.EnteredDate.HasValue &&
                    ticket.DueDate.HasValue &&
                    ticket.EnteredDate > ticket.DueDate)
                {
                    context.ModelState.AddModelError("DueDate", "DueDate has to be later than the EnteredDate");
                    isValid = false;
                }
                if (!isValid)
                {
                    context.Result = new BadRequestObjectResult(context.ModelState);
                }
            }
        }
    }
}
