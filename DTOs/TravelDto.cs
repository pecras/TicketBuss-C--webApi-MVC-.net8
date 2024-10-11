using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketBuss.DTOs
{
     public class TravelDto
    {
        public int TravelID { get; set; }
        public int BusID { get; set; }
        public int DriverID { get; set; }
        public int RouteID { get; set; }
        public string InitialAddress { get; set; } = string.Empty;
        public string ArriveAddress { get; set; } = string.Empty;
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public string TravelIdentifier { get; set; } = string.Empty;
    }
}