namespace PuntoEncuento
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Partido")]
    public partial class Partido
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Partido()
        {
            Localidad = new HashSet<Localidad>();
        }

        [Key]
        public int IdPartido { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        public int? IdProvincia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Localidad> Localidad { get; set; }

        public virtual Provincia Provincia { get; set; }
    }
}
