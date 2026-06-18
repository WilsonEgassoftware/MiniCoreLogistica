using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniCoreLogistica.Data;
using MiniCoreLogistica.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniCoreLogistica.Controllers
{
    public class LogisticaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LogisticaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Carga inicial de la página
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = new ReporteEnviosViewModel();
            return View(model);
        }

        // POST: Recibe el rango de fechas y procesa el reporte
        [HttpPost]
        public async Task<IActionResult> Index(ReporteEnviosViewModel model)
        {
            if (model.FechaInicio == null || model.FechaFin == null)
            {
                ModelState.AddModelError("", "Por favor seleccione ambas fechas.");
                return View(model);
            }

            // Obtener repartidores con sus envíos y zonas
            var repartidoresConEnvios = await _context.Repartidores
                .Include(r => r.Envios.Where(e =>
                    e.fecha_envio >= model.FechaInicio &&
                    e.fecha_envio <= model.FechaFin))
                .ThenInclude(e => e.Zona)
                .ToListAsync();

            model.LineasReporte = new List<FilaReporte>();

            foreach (var rep in repartidoresConEnvios)
            {
                if (rep.Envios.Count == 0)
                {
                    model.LineasReporte.Add(new FilaReporte
                    {
                        Repartidor = rep.nombre,
                        EnviosContados = 0,
                        TotalKg = 0,
                        Zona = "—",
                        TarifaAplicada = 0,
                        CostoTotal = 0,
                        Aplica = false
                    });
                }
                else
                {
                    var agrupadoPorZona = rep.Envios
                        .GroupBy(e => e.Zona)
                        .Select(g => new FilaReporte
                        {
                            Repartidor = rep.nombre,
                            EnviosContados = g.Count(),
                            TotalKg = g.Sum(e => e.peso_kg),
                            Zona = g.Key.nombre_zona,
                            TarifaAplicada = g.Key.tarifa_por_kg,
                            CostoTotal = g.Sum(e => e.peso_kg * g.Key.tarifa_por_kg),
                            Aplica = true
                        });

                    model.LineasReporte.AddRange(agrupadoPorZona);
                }
            }

            return View(model);
        }
    }
}