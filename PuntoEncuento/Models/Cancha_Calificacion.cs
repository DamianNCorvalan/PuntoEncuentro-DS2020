namespace PuntoEncuento
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Cancha_Calificacion
    {
        [Key]
        public int Id_Cancha_Calificacion { get; set; }

        public int IdCalificacion { get; set; }

        public int IdCancha { get; set; }

        public virtual Calificacion Calificacion { get; set; }

        public virtual Cancha Cancha { get; set; }
    }
}
