namespace PuntoEncuento
{
    using System.ComponentModel.DataAnnotations;

    public partial class Precio_Cancha
    {
        [Key]
        public int Id_Precio_Cancha { get; set; }

        public int IdCancha { get; set; }

        public int IdPrecio { get; set; }

        public virtual Cancha Cancha { get; set; }

        public virtual Precio Precio { get; set; }
    }
}
