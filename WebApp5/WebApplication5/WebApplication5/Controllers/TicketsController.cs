using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication5.Filters;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    [ApiController] // not an MVC Controller
    [Route("api/[controller]")]
    //[Version1DiscountinueResourceFilter]
    public class TicketsController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Reading all the tickets"); //status code 200
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok($"Reading ticket #{id}."); //status code 200
        }
        [HttpPost]
        public IActionResult PostV1([FromBody] Ticket ticket)
        {
            return Ok(ticket); //status code 200
        }
        // ACTION FILTER CHANGING PREVIOUS POST
        [HttpPost]
        [Route("~/api/v2/tickets")]
        [Ticket_ValidateDatesActionFilter]
        public IActionResult PostV2([FromBody] Ticket ticket)
        {
            /*
             * => We don't use data annotation because
             * That validation logic will apply to all version
             * We cannot control which version that validation will be applied
             * So we use action filter
             */
            return Ok(ticket); //status code 200
        }
        [HttpPut]
        public IActionResult Put([FromBody] Ticket ticket)
        {
            return Ok(ticket); //status code 200
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok($"Deleting ticket #{id}."); //status code 200
        }
    }
}
