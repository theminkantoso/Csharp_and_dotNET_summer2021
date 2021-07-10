using Core.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication5.Controllers
{
    [ApiController] // not an MVC Controller
    // Project doesnt use ModelState.IsValid in this controller because of this ApiController property to validate
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
