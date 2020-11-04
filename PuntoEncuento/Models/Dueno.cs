namespace PuntoEncuento
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Dueno")]
    public partial class Dueno
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Cuit { get; set; }

        public int? IdUsuario { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
