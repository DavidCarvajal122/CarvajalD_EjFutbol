using CarvajalD_EjFutbol.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CarvajalD_EjFutbol.Repositories
{
    public class EquipoRepository
    {
        private readonly string filePath = Path.Combine(Directory.GetCurrentDirectory(), "App_Data", "equipos.json");

        public EquipoRepository()
        {
            //Sistema de guardado con Json guiado a base de IA y Tutoriales de Youtube:C
            var dir = Path.GetDirectoryName(filePath);
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            if (!File.Exists(filePath))
            {
                var equiposIniciales = new List<Equipo>
                {
                    new Equipo
                    {
                        Id = 1,
                        Nombre = "Liga de Quito",
                        PartidosJugados = 10,
                        PartidosGanados = 10,
                        PartidosEmpatados = 0,
                        PartidosPerdidos = 0
                    },
                    new Equipo
                    {
                        Id = 2,
                        Nombre = "Barcelona",
                        PartidosJugados = 10,
                        PartidosGanados = 8,
                        PartidosEmpatados = 0,
                        PartidosPerdidos = 2
                    },
                    new Equipo
                    {
                        Id = 3,
                        Nombre = "El Nacional",
                        PartidosJugados = 10,
                        PartidosGanados = 8,
                        PartidosEmpatados = 0,
                        PartidosPerdidos = 2
                    },
                    new Equipo
                    {
                        Id = 4,
                        Nombre = "Independiente del Valle",
                        PartidosJugados = 10,
                        PartidosGanados = 8,
                        PartidosEmpatados = 0,
                        PartidosPerdidos = 2
                    }
                };
                GuardarEquipos(equiposIniciales);
            }
        }

        private List<Equipo> LeerEquipos()
        {
            if (!File.Exists(filePath))
                return new List<Equipo>();

            var json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<Equipo>>(json) ?? new List<Equipo>();
        }

        private void GuardarEquipos(List<Equipo> equipos)
        {
            var json = JsonConvert.SerializeObject(equipos, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }

        public IEnumerable<Equipo> DevuelveListadoEquipos()
        {
            return LeerEquipos();
        }

        public Equipo DevuelveEquipoPorID(int Id)
        {
            var equipos = LeerEquipos();
            return equipos.FirstOrDefault(e => e.Id == Id);
        }

        public void AgregarEquipo(Equipo nuevoEquipo)
        {
            var equipos = LeerEquipos();
            nuevoEquipo.Id = equipos.Any() ? equipos.Max(e => e.Id) + 1 : 1;
            equipos.Add(nuevoEquipo);
            GuardarEquipos(equipos);
        }

        public bool ActualizarEquipo(int Id, Equipo equipoActualizado)
        {
            var equipos = LeerEquipos();
            var index = equipos.FindIndex(e => e.Id == Id);
            if (index != -1)
            {
                equipoActualizado.Id = Id;
                equipos[index] = equipoActualizado;
                GuardarEquipos(equipos);
                return true;
            }
            return false;
        }
        public void EliminarEquipo(int id)
        {
            var equipos = LeerEquipos();
            var equipo = equipos.FirstOrDefault(e => e.Id == id);
            if (equipo != null)
            {
                equipos.Remove(equipo);
                GuardarEquipos(equipos);
            }
        }

    }
}

