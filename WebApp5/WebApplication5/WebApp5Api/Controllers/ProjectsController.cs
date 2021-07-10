using Core.Models;
using DataStore.EF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private readonly BugsContext db;

        public ProjectsController(BugsContext db)
        {
            this.db = db;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(db.Projects.ToList()); //status code 200
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var project = db.Projects.Find(id);
            if (project == null)
            {
                return NotFound();
            }
            return Ok(project); //status code 200
        }
        [HttpGet]
        [Route("/api/projects/{pid}/tickets")]

        public IActionResult GetProjectTicket(int pId)
        {
            var tickets = db.Tickets.Where(t => t.ProjectId == pId).ToList();
            if (tickets == null || tickets.Count <= 0)
            {
                return NotFound();
            }
            return Ok(tickets);
        }
        //MODEL BINDING PRIMITIVE
        /*
         * /api/projects/56/tickets?tid=435 or /api/projects/56/tickets
         */
        //[HttpGet]
        //[Route("/api/projects/{pid}/tickets")]

        //public IActionResult GetProjectTicket(int pId, [FromQuery] int tId)
        //{
        //    if (tId == 0)
        //    {
        //        return Ok($"Reading all the tickets belong to project #{pId}");
        //    }
        //    else
        //    {
        //        return Ok($"Reading project #{pId}, ticket #{tId}");
        //    }
        //}
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
        public IActionResult Post([FromBody] Project project)
        {
            db.Projects.Add(project);
            // state added, marked as added
            db.SaveChanges();
            return CreatedAtAction(
                nameof(GetById),
                new { id = project.ProjectId },
                project);
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, Project project)
        {
            if (id != project.ProjectId)
            {
                return BadRequest();
            }
            db.Entry(project).State = EntityState.Modified;
            //what if DB already deleted this particular project
            try
            {
                db.SaveChanges();
            }
            catch
            {
                if(db.Projects.Find(id) == null)
                {
                    return NotFound();
                }
                throw;
            }
            return NoContent(); //status code 200
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var project = db.Projects.Find(id);
            if (project == null) return NotFound();

            db.Projects.Remove(project);
            db.SaveChanges();

            return Ok(project);
        }
    }
}
