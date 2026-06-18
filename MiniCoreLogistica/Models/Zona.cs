using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniCoreLogistica.Models
{
    internal class Zona
    {
        public int id_zona { get; set; }

        public string nombre_zona { get; set; } = string.Empty;

        public decimal tarifa_por_kg { get; set; }

        //relacion inversa con la tabla de pedidos

        public List<envios> envios { get; set; } = new();
    }
}
