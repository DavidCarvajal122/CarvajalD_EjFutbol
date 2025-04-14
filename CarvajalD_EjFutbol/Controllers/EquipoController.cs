using CarvajalD_EjFutbol.Models;
using CarvajalD_EjFutbol.Repositories;
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
            EquipoRepository repository = new EquipoRepository();
            var equipos = repository.DevuelveListadoEquipos();
            equipos = equipos.OrderBy(item => item.PartidosGanados);
            //equipos = equipos.Where(item => item.Nombre == "Nacional"); 
            return View(equipos);
        }

        public ActionResult Create ()
        {
            return View();  
        }

        public ActionResult Edit(int Id)
        {
            EquipoRepository repository = new EquipoRepository();
            var equipo = repository.DevuelveEquipoPorID(Id);
            return View(equipo);
        }
    }
}
