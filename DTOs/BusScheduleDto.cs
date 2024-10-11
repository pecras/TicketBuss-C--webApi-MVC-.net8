using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketBuss.DTOs
{
    public class BusScheduleDto
    {
    public int BusID { get; set; }
    public int RouteID { get; set; }
    public DateTime DepartureTime { get; set; }
    public DateTime ArrivalTime { get; set; }
}
}