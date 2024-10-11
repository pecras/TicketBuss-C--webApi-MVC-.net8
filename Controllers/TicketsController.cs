using Microsoft.AspNetCore.Mvc;
using TicketBuss.DTOs;
using TicketBuss.Models;
using System.Collections.Generic;
using System.Linq;

namespace TicketBuss.Controllers
{
    [ApiController]
    [Route("api/tickets")]
    public class TicketsController : ControllerBase
    {
        private static List<Ticket> tickets = new List<Ticket>();

        [HttpGet]
        public ActionResult<List<Ticket>> GetAll()
        {
            return Ok(tickets);
        }

        [HttpGet("{id}")]
        public ActionResult<Ticket> GetById(int id)
        {
            var ticket = tickets.FirstOrDefault(t => t.TicketID == id);
            if (ticket == null)
                return NotFound();

            return Ok(ticket);
        }

        [HttpPost]
        public ActionResult Create([FromBody] TicketDto ticketDto)
        {
            var newTicket = new Ticket
            {
                TicketID = tickets.Count + 1,
                PassengerID = ticketDto.PassengerID,
                ScheduleID = ticketDto.ScheduleID,
                SeatNumber = ticketDto.SeatNumber,
                BookingDate = ticketDto.BookingDate,
                Price = ticketDto.Price
            };

            tickets.Add(newTicket);

            return CreatedAtAction(nameof(GetById), new { id = newTicket.TicketID }, newTicket);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] TicketDto ticketDto)
        {
            var ticket = tickets.FirstOrDefault(t => t.TicketID == id);
            if (ticket == null)
                return NotFound();

            ticket.PassengerID = ticketDto.PassengerID;
            ticket.ScheduleID = ticketDto.ScheduleID;
            ticket.SeatNumber = ticketDto.SeatNumber;
            ticket.BookingDate = ticketDto.BookingDate;
            ticket.Price = ticketDto.Price;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var ticket = tickets.FirstOrDefault(t => t.TicketID == id);
            if (ticket == null)
                return NotFound();

            tickets.Remove(ticket);

            return NoContent();
        }
    }
}
