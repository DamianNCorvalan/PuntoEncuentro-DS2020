namespace PuntoEncuento
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Disponibilidad")]
    public partial class Disponibilidad
    {
        [Key]
        public int IdDisponibilidad { get; set; }

        public TimeSpan DisponibilidadIinicio { get; set; }

        public TimeSpan DisponibilidadFin { get; set; }

        public int IdDiasSemana { get; set; }

        public int IdCancha { get; set; }

        public virtual Cancha Cancha { get; set; }

        public virtual DiasSemana DiasSemana { get; set; }
    }
}
