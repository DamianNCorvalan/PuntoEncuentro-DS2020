namespace PuntoEncuento
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Reserva")]
    public partial class Reserva
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Reserva()
        {
            Cancelaciones = new HashSet<Cancelaciones>();
        }

        [Key]
        public int IdReserva { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime FechaInicio { get; set; }

        public int IdCancha { get; set; }

        public int DNI { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cancelaciones> Cancelaciones { get; set; }

        public virtual Cancha Cancha { get; set; }

        public virtual Jugador Jugador { get; set; }
    }
}
