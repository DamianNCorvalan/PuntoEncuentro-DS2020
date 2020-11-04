namespace PuntoEncuento
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Cancelaciones
    {
        [Key]
        public int Id_Cancelacion { get; set; }

        [Required]
        [StringLength(200)]
        public string Motivo { get; set; }

        public int IdReserva { get; set; }

        public virtual Reserva Reserva { get; set; }
    }
}
