using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketBuss.Models
{
    public class Routes
    {
        public int RouteID { get; set; }
    public string StartLocation { get; set; } = string.Empty;
    public string EndLocation { get; set; } = string.Empty;
    public TimeSpan Duration { get; set; } // Duração da viagem
    public List<Stop> Stops { get; set; } = []; // Lista de paradas ao longo da rota
    }
}