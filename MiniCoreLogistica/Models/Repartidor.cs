using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniCoreLogistica.Models
{
    internal class Repartidor
    {
        
        public int id_repartidor { get; set; }

     

        public string nombre { get; set; }

        public string email { get; set; }

        //realcion inversa con la tabla de pedidos

        public List<envios> envios { get; set; } = new();
    }
}
