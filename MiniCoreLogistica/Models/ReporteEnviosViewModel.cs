using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniCoreLogistica.Models
{
    internal class ReporteEnviosViewModel
    {
        //Parametro del filtro 

        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }

        //Resultado del reporte
        public List<FilaReporte> LineasReporte { get; set; } = new();

    }
    
    public class FilaReporte     {
        public string Repartidor { get; set; } = string.Empty;
        public int EnviosContados { get; set; }
        public decimal TotalKG { get; set; }
        public string Zona { get; set; } = string.Empty;
        public decimal Tarifcaaplicada { get; set; }
        public decimal CostoTotal { get; set; }
        public bool Aplica { get; set; } = true;
    }

}
