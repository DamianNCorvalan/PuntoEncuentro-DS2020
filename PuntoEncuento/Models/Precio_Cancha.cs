namespace PuntoEncuento
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Precio_Cancha
    {
        [Key]
        public int Id_Precio_Cancha { get; set; }

        public int IdCancha { get; set; }

        public int IdPrecio { get; set; }

        public virtual Cancha Cancha { get; set; }

        public virtual Precio Precio { get; set; }
    }
}
