using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TicketBuss.Models;
using TicketBuss.DTOs;

namespace TicketBuss.Controllers
{
   [Route("api/buses")]
public class BusController : ControllerBase
{
    private static List<Bus> buses = new();

    [HttpGet]
    public ActionResult<List<Bus>> GetAll()
    {
        return Ok(buses);
    }


    [HttpGet("{id}")]
    public ActionResult<Bus> GetById(int id)
    {
        var bus = buses.FirstOrDefault(b => b.BusID == id);
        if (bus == null)
        {
            return NotFound();
        }
        return Ok(bus);
    }



    [HttpPost]
    public ActionResult Create([FromBody] BusDto busDto)
    {
        var newBus = new Bus
        {
            BusID = buses.Count + 1,
            LicensePlate = busDto.LicensePlate,
            BusModel = busDto.BusModel,
            Capacity = busDto.Capacity,
            Status = busDto.Status
        };
        buses.Add(newBus);
        return CreatedAtAction(nameof(GetById), new { id = newBus.BusID }, newBus);
    }

    

    [HttpPut("{id}")]
    public ActionResult Update(int id, [FromBody] UpdateBusDto updateBusDto)
    {
        var bus = buses.FirstOrDefault(b => b.BusID == id);
        if (bus == null)
        {
            return NotFound();
        }

        bus.BusModel = updateBusDto.BusModel;
        bus.Capacity = updateBusDto.Capacity;
        bus.Status = updateBusDto.Status;

        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var bus = buses.FirstOrDefault(b => b.BusID == id);
        if (bus == null)
        {
            return NotFound();
        }

        buses.Remove(bus);
        return NoContent();
    }
}
}