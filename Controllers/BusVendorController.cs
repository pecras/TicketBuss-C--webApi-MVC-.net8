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
[Route("api/busvendors")]
public class BusVendorController : ControllerBase
{
    // Lista temporária simulando um banco de dados
    private static List<BusVendor> busVendors = new();

    // GET: api/busvendors
    [HttpGet]
    public ActionResult<List<BusVendor>> GetBusVendors()
    {
        return Ok(busVendors);
    }

    // GET: api/busvendors/{id}
    [HttpGet("{id}")]
    public ActionResult<BusVendor> GetBusVendorById(int id)
    {
        var busVendor = busVendors.FirstOrDefault(v => v.BusVendorID == id);
        if (busVendor == null)
        {
            return NotFound();
        }
        return Ok(busVendor);
    }

    // POST: api/busvendors
    [HttpPost]
    public ActionResult PostBusVendor([FromBody] BusVendorDto busVendorDto)
    {
        var newBusVendor = new BusVendor
        {
            BusVendorID = busVendors.Count + 1,
            Name = busVendorDto.Name,
            Address = busVendorDto.Address,
            ContactNumber = busVendorDto.ContactNumber,
            Email = busVendorDto.Email
        };

        busVendors.Add(newBusVendor);
        return CreatedAtAction(nameof(GetBusVendorById), new { id = newBusVendor.BusVendorID }, newBusVendor);
    }

    // PUT: api/busvendors/{id}
    [HttpPut("{id}")]
    public ActionResult PutBusVendor(int id, [FromBody] UpdateBusVendorDto updateBusVendorDto)
    {
        var busVendor = busVendors.FirstOrDefault(v => v.BusVendorID == id);
        if (busVendor == null)
        {
            return NotFound();
        }

        busVendor.Address = updateBusVendorDto.Address;
        busVendor.ContactNumber = updateBusVendorDto.ContactNumber;
        busVendor.Email = updateBusVendorDto.Email;

        return NoContent();
    }

    // DELETE: api/busvendors/{id}
    [HttpDelete("{id}")]
    public ActionResult DeleteBusVendor(int id)
    {
        var busVendor = busVendors.FirstOrDefault(v => v.BusVendorID == id);
        if (busVendor == null)
        {
            return NotFound();
        }

        busVendors.Remove(busVendor);
        return NoContent();
    }
}
}