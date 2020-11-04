namespace PuntoEncuento
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

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
