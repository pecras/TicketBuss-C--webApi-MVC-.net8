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
[Route("api/passengers")]
public class PassengerController : ControllerBase
{
    private static List<Passenger> passengers = new();

    [HttpGet]
    public ActionResult<List<Passenger>> GetAll()
    {
        return Ok(passengers);
    }

    [HttpGet("{id}")]
    public ActionResult<Passenger> GetById(int id)
    {
        var passenger = passengers.FirstOrDefault(p => p.PassengerID == id);
        if (passenger == null)
        {
            return NotFound();
        }
        return Ok(passenger);
    }

    [HttpPost]
    public ActionResult Create([FromBody] PassengerDto passengerDto)
    {
        var newPassenger = new Passenger
        {
            PassengerID = passengers.Count + 1,
            FullName = passengerDto.FullName,
            Email = passengerDto.Email,
            Phone = passengerDto.Phone
        };
        passengers.Add(newPassenger);
        return CreatedAtAction(nameof(GetById), new { id = newPassenger.PassengerID }, newPassenger);
    }

    [HttpPut("{id}")]
    public ActionResult Update(int id, [FromBody] PassengerDto passengerDto)
    {
        var passenger = passengers.FirstOrDefault(p => p.PassengerID == id);
        if (passenger == null)
        {
            return NotFound();
        }

        passenger.FullName = passengerDto.FullName;
        passenger.Email = passengerDto.Email;
        passenger.Phone = passengerDto.Phone;

        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var passenger = passengers.FirstOrDefault(p => p.PassengerID == id);
        if (passenger == null)
        {
            return NotFound();
        }

        passengers.Remove(passenger);
        return NoContent();
    }
}

    
}