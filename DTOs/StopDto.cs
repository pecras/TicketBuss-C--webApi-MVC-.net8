using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

   namespace TicketBuss.Dtos
{
    public class StopDto
    {
        public int StopID { get; set; }
        public string StopName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
    }
}
     
