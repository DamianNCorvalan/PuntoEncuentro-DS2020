namespace PuntoEncuento
{
    using System.ComponentModel.DataAnnotations;

    public partial class Disciplina_Cancha
    {
        [Key]
        public int Id_Disciplina_Cancha { get; set; }

        public int IdCancha { get; set; }

        public int IdDisciplina { get; set; }

        public virtual Cancha Cancha { get; set; }

        public virtual Disciplina Disciplina { get; set; }
    }
}
