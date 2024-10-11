using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketBuss.Models
{
  public class BusVendor
{
    public int BusVendorID { get; set; }  // Identificador único do fornecedor
    public string Name { get; set; }  = string.Empty;     // Nome do fornecedor
    public string Address { get; set; } =string.Empty;   // Endereço do fornecedor
    public string ContactNumber { get; set; } =string.Empty; // Número de contato
    public string Email { get; set; }  =string.Empty;    // Email do fornecedor
}
}