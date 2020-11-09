namespace PuntoEncuento
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Dueno")]
    public partial class Dueno
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Cuit { get; set; }

        public int? IdUsuario { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
