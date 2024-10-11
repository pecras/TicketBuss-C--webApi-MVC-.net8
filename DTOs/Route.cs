using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketBuss.DTOs
{
    public class RouteDto
    {
    public string StartLocation { get; set; } = string.Empty;
    public string EndLocation { get; set; }  = string.Empty;
    public TimeSpan Duration { get; set; }
    public List<int> StopIDs { get; set; }   = [] ;// IDs das paradas
}
}