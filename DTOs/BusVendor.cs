using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketBuss.DTOs
{
    public class BusVendorDto
{
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string ContactNumber { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}

public class UpdateBusVendorDto
{
    public string Address { get; set; } =string.Empty;

    public string ContactNumber { get; set; } = string.Empty;

    public string Email { get; set; }= string.Empty;
}
}