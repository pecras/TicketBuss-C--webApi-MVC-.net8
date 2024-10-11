using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketBuss.Models
{
    public class Travel
{
    public int TravelID { get; set; }
    public int BusID { get; set; }
    public Bus Bus { get; set; }  // Associação com o ônibus

    public  Driver Driver{get;set;}

    public int DriverID {get;set;}

    public int RouteID { get; set; }
    public Route Route { get; set; }  // Associação com a rota

 public required string InitialAddress {get;set;}

    public  required string ArriveAddress { get; set; }
    public DateTime DepartureTime { get; set; }  // Horário de partida
    public DateTime ArrivalTime { get; set; }    // Horário de chegada
    public string TravelIdentifier { get; set; } = string.Empty;  // Identificação da viagem
}
}

