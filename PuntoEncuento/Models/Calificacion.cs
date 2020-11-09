namespace PuntoEncuento
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Calificacion")]
    public partial class Calificacion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Calificacion()
        {
            Cancha_Calificacion = new HashSet<Cancha_Calificacion>();
            Predio_Calificacion = new HashSet<Predio_Calificacion>();
            Usuario_Calificacion = new HashSet<Usuario_Calificacion>();
        }

        [Key]
        public int IdCalificacion { get; set; }

        [Required]
        [StringLength(30)]
        public string TipoCalificacion { get; set; }

        public string Comentario { get; set; }

        public byte[] ImagenCalif { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cancha_Calificacion> Cancha_Calificacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Predio_Calificacion> Predio_Calificacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Usuario_Calificacion> Usuario_Calificacion { get; set; }
    }
}
