namespace PuntoEncuento
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Inhabilitacion")]
    public partial class Inhabilitacion
    {
        [Key]
        public int IdInhabilitacion { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime DiaInicio { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime DiaFIn { get; set; }

        public int IdCancha { get; set; }

        public virtual Cancha Cancha { get; set; }
    }
}
