using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketBuss.Models
{
    public class Payment
    {
        public int PaymentID { get; set; }
    public int TicketID { get; set; }
    public DateTime PaymentDate { get; set; }
    public string PaymentMethod { get; set; }= string.Empty;
    public decimal Amount { get; set; }
    }
}