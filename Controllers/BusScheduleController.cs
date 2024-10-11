using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TicketBuss.Models;
using TicketBuss.DTOs;

namespace TicketBuss.Controllers
{
    [ApiController]
[Route("api/schedules")]
public class BusScheduleController : ControllerBase
{
    private static List<BusSchedule> schedules = new();

    [HttpGet]
    public ActionResult<List<BusSchedule>> GetAll()
    {
        return Ok(schedules);
    }

    [HttpGet("{id}")]
    public ActionResult<BusSchedule> GetById(int id)
    {
        var schedule = schedules.FirstOrDefault(s => s.ScheduleID == id);
        if (schedule == null)
        {
            return NotFound();
        }
        return Ok(schedule);
    }

    [HttpPost]
    public ActionResult Create([FromBody] BusScheduleDto scheduleDto)
    {
        var newSchedule = new BusSchedule
        {
            ScheduleID = schedules.Count + 1,
            BusID = scheduleDto.BusID,
            RouteID = scheduleDto.RouteID,
            DepartureTime = scheduleDto.DepartureTime,
            ArrivalTime = scheduleDto.ArrivalTime
        };
        schedules.Add(newSchedule);
        return CreatedAtAction(nameof(GetById), new { id = newSchedule.ScheduleID }, newSchedule);
    }

    [HttpPut("{id}")]
    public ActionResult Update(int id, [FromBody] BusScheduleDto scheduleDto)
    {
        var schedule = schedules.FirstOrDefault(s => s.ScheduleID == id);
        if (schedule == null)
        {
            return NotFound();
        }

        schedule.BusID = scheduleDto.BusID;
        schedule.RouteID = scheduleDto.RouteID;
        schedule.DepartureTime = scheduleDto.DepartureTime;
        schedule.ArrivalTime = scheduleDto.ArrivalTime;

        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var schedule = schedules.FirstOrDefault(s => s.ScheduleID == id);
        if (schedule == null)
        {
            return NotFound();
        }

        schedules.Remove(schedule);
        return NoContent();
    }
}
}