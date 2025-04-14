using CarvajalD_EjFutbol.Models;

namespace CarvajalD_EjFutbol.Repositories
{
    public class EquipoRepository
    {
        public IEnumerable<Equipo> DevuelveListadoEquipos()
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
            Equipo nacional = new Equipo
            {
                Id = 2,
                Nombre = "Nacional",
                PartidosJugados = 10,
                PartidosEmpatados = 3,
                PartidosGanados = 6,
                PartidosPerdidos = 1
            };
            equipos.Add(ldu);
            equipos.Add(nacional);
            return equipos;
        }

        public Equipo DevuelveEquipoPorID(int Id)
        {
            var equipos = DevuelveListadoEquipos();
            var equipo = equipos.First(item=> item.Id == Id);
            return equipo; 
        }
    }
}
