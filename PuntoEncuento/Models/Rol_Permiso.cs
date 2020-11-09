namespace PuntoEncuento
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Rol_Permiso
    {
        [Key]
        public int Id_Rol_Permiso { get; set; }

        public int IdRol { get; set; }

        public int IdPermiso { get; set; }

        public virtual Permiso Permiso { get; set; }

        public virtual Rol Rol { get; set; }
    }
}
