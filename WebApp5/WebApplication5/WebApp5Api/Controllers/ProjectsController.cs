using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication5.Controllers
{
    [ApiController] // not an MVC Controller
    [Route("api/[controller]")]
    public class ProjectsController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Reading all the projects"); //status code 200
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok($"Reading project #{id}."); //status code 200
        }
        //MODEL BINDING PRIMITIVE
        /*
         * /api/projects/56/tickets?tid=435 or /api/projects/56/tickets
         */
        [HttpGet]
        [Route("/api/projects/{pid}/tickets")]

        public IActionResult GetProjectTicket(int pId, [FromQuery] int tId)
        {
            if (tId == 0)
            {
                return Ok($"Reading all the tickets belong to project #{pId}");
            }
            else
            {
                return Ok($"Reading project #{pId}, ticket #{tId}");
            }
        }
        //MODEL BINDING COMPLEX
        //[HttpGet]
        //[Route("/api/projects/{pid}/tickets")]
        ///*
        // * api/projects/535/tickets?tid=3&title=abc&description=hello%20abc
        // */
        //public IActionResult GetProjectTicket([FromQuery] Ticket ticket)
        //{
        //    if (ticket == null)
        //    {
        //        return BadRequest("Parameters are not provided properly!");
        //    }
        //    else if (ticket.TicketId == 0)
        //    {
        //        return Ok($"Reading all the tickets belong to project #{ticket.ProjectId}");
        //    }
        //    else
        //    {
        //        return Ok($"Reading project #{ticket.ProjectId}, ticket #{ticket.TicketId}, title: {ticket.Title}, description: {ticket.Description}.");
        //    }
        //}
        [HttpPost]
        public IActionResult Post()
        {
            return Ok("Creating a project"); //status code 200
        }
        [HttpPut]
        public IActionResult Put()
        {
            return Ok("Updating a project"); //status code 200
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok($"Deleting project #{id}."); //status code 200
        }
    }
}
