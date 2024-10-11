using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketBuss.DTOs
{



    public class BusDto
{
    public string LicensePlate { get; set; } = string.Empty;
    public string BusModel { get; set; } = "convencional";
    public int Capacity { get; set; } = 42 ;
    public string Status { get; set; }= string.Empty;
}

public class UpdateBusDto
{
    public string BusModel { get; set; } = string.Empty;
    public int Capacity { get; set; }
    public string Status { get; set; } = string.Empty;
}

}