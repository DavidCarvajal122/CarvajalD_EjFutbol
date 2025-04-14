using CarvajalD_EjFutbol.Models;
using CarvajalD_EjFutbol.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarvajalD_EjFutbol.Controllers
{
    public class EquipoController : Controller
    {
        public EquipoRepository _repository;

        public EquipoController()
        {
            _repository = new EquipoRepository()    ;
        }
        public ActionResult View()
        {
            return View();
        }

        public ActionResult List()
        {
            var equipos = _repository.DevuelveListadoEquipos();
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
            var equipo = _repository.DevuelveEquipoPorID(Id);
            return View(equipo);
        }

        [HttpPost]
        public ActionResult Edit(int Id, Equipo equipo)
        {
            
            try
            {
                
                //Proceso Guardar
                _repository.ActualizarEquipo(Id, equipo);
                return RedirectToAction(nameof(List));
            }
            catch 
            { 
                return View();
            }
        }
    }
}
