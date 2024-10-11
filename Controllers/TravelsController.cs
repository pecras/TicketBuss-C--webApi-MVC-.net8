using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TicketBuss.Models;
using TicketBuss.DTOs;

namespace TicketBuss.Controllers
{
    [ApiController]
    [Route("api/travels")]
    public class TravelsController : ControllerBase
    {
        private static List<Travel> Travels = new();

        [HttpGet("{id}")]
        public ActionResult<Travel> GetById(int id)
        {
            var travel = Travels.FirstOrDefault(t => t.TravelID == id);
            if (travel == null)
                return NotFound();

            return Ok(travel);
        }

        [HttpGet("departure/{initialAddress}")]
        public ActionResult<List<Travel>> GetByInitialAddress(string initialAddress)
        {
            var travels = Travels.Where(t => t.InitialAddress == initialAddress).ToList();
            if (!travels.Any())
                return NotFound();

            return Ok(travels);
        }

        [HttpGet("filter")]
        public ActionResult<List<Travel>> GetByInitialOrArriveAddress(
            [FromQuery] string? initialAddress,
            [FromQuery] string? arriveAddress)
        {
            var travels = Travels.Where(t => 
                (string.IsNullOrEmpty(initialAddress) || t.InitialAddress == initialAddress) &&
                (string.IsNullOrEmpty(arriveAddress) || t.ArriveAddress == arriveAddress)
            ).ToList();

            if (!travels.Any())
                return NotFound();

            return Ok(travels);
        }

        [HttpGet("driver/{driverId}")]
        public ActionResult<List<Travel>> GetByDriver(int driverId)
        {
            var travels = Travels.Where(t => t.DriverID == driverId).ToList();
            if (!travels.Any())
                return NotFound();

            return Ok(travels);
        }

        [HttpGet("departuretime/{departureTime}")]
        public ActionResult<List<Travel>> GetByDepartureTime(DateTime departureTime)
        {
            var travels = Travels.Where(t => t.DepartureTime.Date == departureTime.Date).ToList();
            if (!travels.Any())
                return NotFound();

            return Ok(travels);
        }

        [HttpPost]
        public ActionResult Create([FromBody] TravelDto travelDto)
        {
            var newTravel = new Travel
            {
                TravelID = Travels.Count + 1,
                BusID = travelDto.BusID,
                DriverID = travelDto.DriverID,
                RouteID = travelDto.RouteID,
                InitialAddress = travelDto.InitialAddress,
                ArriveAddress = travelDto.ArriveAddress,
                DepartureTime = travelDto.DepartureTime,
                ArrivalTime = travelDto.ArrivalTime,
                TravelIdentifier = travelDto.TravelIdentifier
            };

            Travels.Add(newTravel);
            return CreatedAtAction(nameof(GetById), new { id = newTravel.TravelID }, newTravel);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] TravelDto travelDto)
        {
            var travel = Travels.FirstOrDefault(t => t.TravelID == id);
            if (travel == null)
                return NotFound();

            travel.BusID = travelDto.BusID;
            travel.DriverID = travelDto.DriverID;
            travel.RouteID = travelDto.RouteID;
            travel.InitialAddress = travelDto.InitialAddress;
            travel.ArriveAddress = travelDto.ArriveAddress;
            travel.DepartureTime = travelDto.DepartureTime;
            travel.ArrivalTime = travelDto.ArrivalTime;
            travel.TravelIdentifier = travelDto.TravelIdentifier;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var travel = Travels.FirstOrDefault(t => t.TravelID == id);
            if (travel == null)
                return NotFound();

            Travels.Remove(travel);
            return NoContent();
        }
    }
}
