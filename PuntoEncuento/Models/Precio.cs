namespace PuntoEncuento
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Precio")]
    public partial class Precio
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Precio()
        {
            Precio_Cancha = new HashSet<Precio_Cancha>();
        }

        [Key]
        public int IdPrecio { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Column("precio")]
        public int precio1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Precio_Cancha> Precio_Cancha { get; set; }
    }
}
