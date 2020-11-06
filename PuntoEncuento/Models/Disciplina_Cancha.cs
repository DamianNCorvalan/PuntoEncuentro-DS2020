namespace PuntoEncuento
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

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
