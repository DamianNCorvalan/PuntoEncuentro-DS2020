namespace PuntoEncuento
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("DiasSemana")]
    public partial class DiasSemana
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DiasSemana()
        {
            Disponibilidad = new HashSet<Disponibilidad>();
        }

        [Key]
        public int IdDiasSemana { get; set; }

        [Required]
        [StringLength(10)]
        public string Nombre { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Disponibilidad> Disponibilidad { get; set; }
    }
}
