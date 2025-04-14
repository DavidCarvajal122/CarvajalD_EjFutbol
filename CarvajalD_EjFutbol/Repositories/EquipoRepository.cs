using CarvajalD_EjFutbol.Models;

namespace CarvajalD_EjFutbol.Repositories
{
    public class EquipoRepository
    {
        public IEnumerable<Equipo> Equipos;

        public EquipoRepository()
        {
            Equipos = DevuelveListadoEquipos();
        }


        public void InicializarEquipos()
        {
            List<Equipo> equipos = new List<Equipo>();

            Equipo ldu = new Equipo
            {
                Id = 1,
                Nombre = "Liga de Quito",
                PartidosJugados = 10,
                PartidosGanados = 10,
                PartidosEmpatados = 0,
                PartidosPerdidos = 0
            };

            Equipo barcelona = new Equipo
            {
                Id = 2,
                Nombre = "Barcelona",
                PartidosJugados = 10,
                PartidosGanados = 8,
                PartidosEmpatados = 0,
                PartidosPerdidos = 2
            };
            equipos.Add(ldu);
            equipos.Add(barcelona);

            Equipos = equipos;
        }

        public IEnumerable<Equipo> DevuelveListadoEquipos()
        {
            return Equipos;
        }

        public Equipo DevuelveEquipoPorID(int Id)
        {
            var equipo = Equipos.First(item => item.Id == Id);

            return equipo;
        }


        public bool CrearEquipo(Equipo equipo)
        {
            Equipos.ToList().Add(equipo);

            return true;
        }

        public bool ActualizarEquipo(int Id, Equipo equipo)
        {
            //Logica de actualizacion

            return true;
        }
    }
}
