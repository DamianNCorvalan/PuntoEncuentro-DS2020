namespace PuntoEncuento
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Equipo")]
    public partial class Equipo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Equipo()
        {
            Jugador_Equipo = new HashSet<Jugador_Equipo>();
        }

        [Key]
        public int IdEquipo { get; set; }

        [Required]
        public string Nombre { get; set; }

        public int IdDisciplina { get; set; }

        public string ImagenEquipo { get; set; }

        public virtual Disciplina Disciplina { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Jugador_Equipo> Jugador_Equipo { get; set; }
    }
}
