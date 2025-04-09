using CarvajalD_EjFutbol.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarvajalD_EjFutbol.Controllers
{
    public class EquipoController : Controller
    {
        public ActionResult View()
        {
            return View();
        }

        public ActionResult List()
        {
            List<Equipo> equipos = new List<Equipo>();

            Equipo ldu = new Equipo
            {
                Id = 1,
                Nombre = "Liga de Quito",
                PartidosJugados = 10,
                PartidosEmpatados = 0,
                PartidosGanados = 10,
                PartidosPerdidos = 0
            }; 
            equipos.Add(ldu);
            return View(equipos);  
        }
    }
}
