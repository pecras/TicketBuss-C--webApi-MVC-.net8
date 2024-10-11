using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketBuss.Models
{
    public class Bus
    {
        public int BusID { get; set; }
    public string LicensePlate { get; set; } = string.Empty;
    public string BusModel { get; set; } = "Convencional";
    public int Capacity { get; set; } = 42 ;
    public string Status { get; set; } = "É o mais econômico e básico dos tipos de ônibus oferecidos pelas empresas. É o mais indicado para viagens de curta duração, pois não oferece serviços extras e, normalmente, possui poltronas convencionais acolchoadas, mas pouco reclináveis.Essa categoria possui cerca de 42 lugares, comportando os passageiros com exatidão, mas sem folgas. Alguns ônibus contam também com ar-condicionado e banheiro.";
    }

    
}  