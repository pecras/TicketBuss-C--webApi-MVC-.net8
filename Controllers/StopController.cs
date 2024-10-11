using Microsoft.AspNetCore.Mvc;
using TicketBuss.Models;
using TicketBuss.Dtos;
using System.Collections.Generic;
using System.Linq;

namespace TicketBuss.Controllers
{
    [ApiController]
    [Route("api/stops")]
    public class StopController : ControllerBase
    {
        // Lista temporária simulando um banco de dados
        private static List<Stop> stops = new List<Stop>
        {
            new Stop { StopID = 1, StopName = "Central Station", Address = "123 Main St" },
            new Stop { StopID = 2, StopName = "West Station", Address = "456 West St" }
        };

        [HttpGet]
        public ActionResult<List<StopDto>> GetAllStops()
        {
            var stopDtos = stops.Select(s => new StopDto
            {
                StopID = s.StopID,
                StopName = s.StopName,
                Address = s.Address
            }).ToList();

            return Ok(stopDtos);
        }

        [HttpGet("{id}")]
        public ActionResult<StopDto> GetStopById(int id)
        {
            var stop = stops.FirstOrDefault(s => s.StopID == id);
            if (stop == null)
            {
                return NotFound();
            }

            var stopDto = new StopDto
            {
                StopID = stop.StopID,
                StopName = stop.StopName,
                Address = stop.Address
            };

            return Ok(stopDto);
        }

        [HttpPost]
        public ActionResult CreateStop([FromBody] StopDto stopDto)
        {
            var newStop = new Stop
            {
                StopID = stops.Count + 1,
                StopName = stopDto.StopName,
                Address = stopDto.Address
            };

            stops.Add(newStop);

            return CreatedAtAction(nameof(GetStopById), new { id = newStop.StopID }, newStop);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateStop(int id, [FromBody] StopDto stopDto)
        {
            var stop = stops.FirstOrDefault(s => s.StopID == id);
            if (stop == null)
            {
                return NotFound();
            }

            stop.StopName = stopDto.StopName;
            stop.Address = stopDto.Address;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteStop(int id)
        {
            var stop = stops.FirstOrDefault(s => s.StopID == id);
            if (stop == null)
            {
                return NotFound();
            }

            stops.Remove(stop);

            return NoContent();
        }
    }
}
