namespace PuntoEncuento
{
    using System.ComponentModel.DataAnnotations;

    public partial class Cancha_Calificacion
    {
        [Key]
        public int Id_Cancha_Calificacion { get; set; }

        public int IdCalificacion { get; set; }

        public int IdCancha { get; set; }

        public virtual Calificacion Calificacion { get; set; }

        public virtual Cancha Cancha { get; set; }
    }
}
