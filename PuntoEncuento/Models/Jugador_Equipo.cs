namespace PuntoEncuento
{
    using System.ComponentModel.DataAnnotations;

    public partial class Jugador_Equipo
    {
        [Key]
        public int Id_Jugador_Equipo { get; set; }

        public int DNI { get; set; }

        public int? IdEquipo { get; set; }

        public virtual Equipo Equipo { get; set; }

        public virtual Jugador Jugador { get; set; }
    }
}
