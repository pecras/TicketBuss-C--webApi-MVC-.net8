using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketBuss.DTOs
{
    public class TicketDto
    {
        public int PassengerID { get; set; }
        public int ScheduleID { get; set; }
        public int SeatNumber { get; set; }
        public DateTime BookingDate { get; set; }
        public decimal Price { get; set; }
    }
}