namespace CarvajalD_EjFutbol.Models
{
    public class Equipo
    {
        public int Id { get; set; } // Estructura de atributo 
        public string Nombre { get; set; }
        public int PartidosJugados { get; set; }
        public int PartidosGanados { get; set; }
        public int PartidosPerdidos { get; set ;}
        public int PartidosEmpatados { get; set; }

    }
}
