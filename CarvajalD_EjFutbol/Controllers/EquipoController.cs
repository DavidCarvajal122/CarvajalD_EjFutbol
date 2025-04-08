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
            return View(equipos);  
        }
    }
}
