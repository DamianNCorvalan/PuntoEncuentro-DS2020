namespace PuntoEncuento
{
    using System.ComponentModel.DataAnnotations;

    public partial class Cancelaciones
    {
        [Key]
        public int Id_Cancelacion { get; set; }

        [Required]
        [StringLength(200)]
        public string Motivo { get; set; }

        public int IdReserva { get; set; }

        public virtual Reserva Reserva { get; set; }
    }
}
