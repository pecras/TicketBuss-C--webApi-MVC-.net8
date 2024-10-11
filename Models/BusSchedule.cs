using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketBuss.Models
{
    public class BusSchedule
    {
        public int ScheduleID { get; set; }
    public int BusID { get; set; }
    public int RouteID { get; set; }
    public DateTime DepartureTime { get; set; }
    public DateTime ArrivalTime { get; set; }
    }
}