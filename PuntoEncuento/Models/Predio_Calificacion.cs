namespace PuntoEncuento
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Predio_Calificacion
    {
        [Key]
        public int Id_Predio_Calificacion { get; set; }

        public int IdCalificacion { get; set; }

        public int IdPredio { get; set; }

        public virtual Calificacion Calificacion { get; set; }

        public virtual Predio Predio { get; set; }
    }
}
