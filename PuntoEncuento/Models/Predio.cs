namespace PuntoEncuento
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Predio")]
    public partial class Predio
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Predio()
        {
            Cancha = new HashSet<Cancha>();
            Predio_Calificacion = new HashSet<Predio_Calificacion>();
        }

        [Key]
        public int IdPredio { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public byte[] ImagenPredio { get; set; }

        public int IdDomicilio { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cancha> Cancha { get; set; }

        public virtual Domicilio Domicilio { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Predio_Calificacion> Predio_Calificacion { get; set; }
    }
}
