namespace PuntoEncuento
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Domicilio")]
    public partial class Domicilio
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Domicilio()
        {
            Predio = new HashSet<Predio>();
            Usuario = new HashSet<Usuario>();
        }

        [Key]
        public int IdDomicilio { get; set; }

        [Required]
        [StringLength(100)]
        public string Calle { get; set; }

        [Required]
        [StringLength(20)]
        public string Altura { get; set; }

        [Required]
        [StringLength(20)]
        public string CodigoPostal { get; set; }

        public int IdLocalidad { get; set; }

        public virtual Localidad Localidad { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Predio> Predio { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
