using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniCoreLogistica.Models
{
    internal class Envio
    {
        public int id_envio { get; set; }

        public int id_repartidor { get; set; }
        public Repartidor repartidor { get; set; } = null;
        
        public int id_zona { get; set; }
        public Zona zona { get; set; } = null;

        public decimal peso { get; set; }   

        public DateTime fecha_envio { get; set; }
    }
}
