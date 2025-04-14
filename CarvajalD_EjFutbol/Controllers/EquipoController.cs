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
            _repository = new EquipoRepository();
        }

        public ActionResult View()
        {
            return View();
        }

        public ActionResult List()
        {
            var equipos = _repository.DevuelveListadoEquipos();
            equipos = equipos.OrderByDescending(item => (item.PartidosGanados * 3) + item.PartidosEmpatados);
            return View(equipos);
        }

        public ActionResult Create()
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
                // Proceso Guardar
                _repository.ActualizarEquipo(Id, equipo);
                return RedirectToAction(nameof(List));
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Create(Equipo equipo)
        {
            if (ModelState.IsValid)
            {
                _repository.AgregarEquipo(equipo);
                return RedirectToAction("List");
            }
            return View(equipo);
        }

        public ActionResult Delete(int id)
        {
            var equipo = _repository.DevuelveEquipoPorID(id);
            return View(equipo);
        }

        [HttpPost]
        public ActionResult Delete(Equipo equipo)
        {
            _repository.EliminarEquipo(equipo.Id);
            return RedirectToAction(nameof(List));
        }
        public ActionResult Details(int id)
        {
            var equipo = _repository.DevuelveEquipoPorID(id);
            if (equipo == null)
            {
                return NotFound(); 
            }
            return View(equipo);
        }

    }
}
