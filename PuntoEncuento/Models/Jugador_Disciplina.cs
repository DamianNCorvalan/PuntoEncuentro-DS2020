namespace PuntoEncuento
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Jugador_Disciplina
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id_Jugador_Disciplina { get; set; }

        public int DNI { get; set; }

        public int IdDisciplina { get; set; }

        public virtual Disciplina Disciplina { get; set; }

        public virtual Jugador Jugador { get; set; }
    }
}
