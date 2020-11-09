namespace PuntoEncuento
{
    using System.ComponentModel.DataAnnotations;

    public partial class Usuario_Calificacion
    {
        [Key]
        public int Id_Usuario_Calificacion { get; set; }

        public int IdCalificacion { get; set; }

        public int IdUsuario { get; set; }

        public virtual Calificacion Calificacion { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
