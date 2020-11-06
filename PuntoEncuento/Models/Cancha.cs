namespace PuntoEncuento
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Cancha")]
    public partial class Cancha
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cancha()
        {
            Cancha_Calificacion = new HashSet<Cancha_Calificacion>();
            Disciplina_Cancha = new HashSet<Disciplina_Cancha>();
            Disponibilidad = new HashSet<Disponibilidad>();
            Inhabilitacion = new HashSet<Inhabilitacion>();
            Precio_Cancha = new HashSet<Precio_Cancha>();
            Reserva = new HashSet<Reserva>();
        }

        [Key]
        public int IdCancha { get; set; }

        [Required]
        [StringLength(35)]
        public string Nombre { get; set; }

        public bool Techado { get; set; }

        public int IdPredio { get; set; }

        [Required]
        public byte[] ImagenCancha { get; set; }

        public int TiempoReserva { get; set; }

        public int IdSuelo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cancha_Calificacion> Cancha_Calificacion { get; set; }

        public virtual Predio Predio { get; set; }

        public virtual Suelo Suelo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Disciplina_Cancha> Disciplina_Cancha { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Disponibilidad> Disponibilidad { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Inhabilitacion> Inhabilitacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Precio_Cancha> Precio_Cancha { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reserva> Reserva { get; set; }
    }
}
