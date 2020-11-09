namespace PuntoEncuento
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Capitan")]
    public partial class Capitan
    {
        [Key]
        public int IdCapitan { get; set; }

        public int? DNI { get; set; }

        public virtual Jugador Jugador { get; set; }
    }
}
