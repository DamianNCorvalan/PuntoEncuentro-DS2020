namespace PuntoEncuento
{
    using System.Data.Entity;

    public partial class PuntoEncuentroDataContext : DbContext
    {
        public PuntoEncuentroDataContext()
            : base("name=PuntoEncuentroDataContext")
        {
        }

        public virtual DbSet<Administrador> Administrador { get; set; }
        public virtual DbSet<Calificacion> Calificacion { get; set; }
        public virtual DbSet<Cancelaciones> Cancelaciones { get; set; }
        public virtual DbSet<Cancha> Cancha { get; set; }
        public virtual DbSet<Cancha_Calificacion> Cancha_Calificacion { get; set; }
        public virtual DbSet<Capitan> Capitan { get; set; }
        public virtual DbSet<DiasSemana> DiasSemana { get; set; }
        public virtual DbSet<Disciplina> Disciplina { get; set; }
        public virtual DbSet<Disciplina_Cancha> Disciplina_Cancha { get; set; }
        public virtual DbSet<Disponibilidad> Disponibilidad { get; set; }
        public virtual DbSet<Domicilio> Domicilio { get; set; }
        public virtual DbSet<Dueno> Dueno { get; set; }
        public virtual DbSet<Equipo> Equipo { get; set; }
        public virtual DbSet<Inhabilitacion> Inhabilitacion { get; set; }
        public virtual DbSet<Jugador> Jugador { get; set; }
        public virtual DbSet<Jugador_Disciplina> Jugador_Disciplina { get; set; }
        public virtual DbSet<Jugador_Equipo> Jugador_Equipo { get; set; }
        public virtual DbSet<Localidad> Localidad { get; set; }
        public virtual DbSet<Partido> Partido { get; set; }
        public virtual DbSet<Permiso> Permiso { get; set; }
        public virtual DbSet<Precio> Precio { get; set; }
        public virtual DbSet<Precio_Cancha> Precio_Cancha { get; set; }
        public virtual DbSet<Predio> Predio { get; set; }
        public virtual DbSet<Predio_Calificacion> Predio_Calificacion { get; set; }
        public virtual DbSet<Provincia> Provincia { get; set; }
        public virtual DbSet<Reserva> Reserva { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<Rol_Permiso> Rol_Permiso { get; set; }
        public virtual DbSet<Suelo> Suelo { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Usuario_Calificacion> Usuario_Calificacion { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrador>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Administrador>()
                .Property(e => e.Apellido)
                .IsUnicode(false);

            modelBuilder.Entity<Administrador>()
                .Property(e => e.CorreoElectronico)
                .IsUnicode(false);

            modelBuilder.Entity<Calificacion>()
                .Property(e => e.TipoCalificacion)
                .IsUnicode(false);

            modelBuilder.Entity<Calificacion>()
                .Property(e => e.Comentario)
                .IsUnicode(false);

            modelBuilder.Entity<Calificacion>()
                .HasMany(e => e.Cancha_Calificacion)
                .WithRequired(e => e.Calificacion)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Calificacion>()
                .HasMany(e => e.Predio_Calificacion)
                .WithRequired(e => e.Calificacion)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Calificacion>()
                .HasMany(e => e.Usuario_Calificacion)
                .WithRequired(e => e.Calificacion)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Cancelaciones>()
                .Property(e => e.Motivo)
                .IsUnicode(false);

            modelBuilder.Entity<Cancha>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Cancha>()
                .HasMany(e => e.Cancha_Calificacion)
                .WithRequired(e => e.Cancha)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Cancha>()
                .HasMany(e => e.Disciplina_Cancha)
                .WithRequired(e => e.Cancha)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Cancha>()
                .HasMany(e => e.Disponibilidad)
                .WithRequired(e => e.Cancha)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Cancha>()
                .HasMany(e => e.Inhabilitacion)
                .WithRequired(e => e.Cancha)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Cancha>()
                .HasMany(e => e.Precio_Cancha)
                .WithRequired(e => e.Cancha)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Cancha>()
                .HasMany(e => e.Reserva)
                .WithRequired(e => e.Cancha)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DiasSemana>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<DiasSemana>()
                .HasMany(e => e.Disponibilidad)
                .WithRequired(e => e.DiasSemana)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Disciplina>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Disciplina>()
                .HasMany(e => e.Disciplina_Cancha)
                .WithRequired(e => e.Disciplina)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Disciplina>()
                .HasMany(e => e.Equipo)
                .WithRequired(e => e.Disciplina)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Disciplina>()
                .HasMany(e => e.Jugador_Disciplina)
                .WithRequired(e => e.Disciplina)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Domicilio>()
                .Property(e => e.Calle)
                .IsUnicode(false);

            modelBuilder.Entity<Domicilio>()
                .Property(e => e.Altura)
                .IsUnicode(false);

            modelBuilder.Entity<Domicilio>()
                .Property(e => e.CodigoPostal)
                .IsUnicode(false);

            modelBuilder.Entity<Domicilio>()
                .HasMany(e => e.Predio)
                .WithRequired(e => e.Domicilio)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Domicilio>()
                .HasMany(e => e.Usuario)
                .WithRequired(e => e.Domicilio)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Equipo>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Equipo>()
                .Property(e => e.ImagenEquipo)
                .IsUnicode(false);

            modelBuilder.Entity<Jugador>()
                .HasMany(e => e.Jugador_Disciplina)
                .WithRequired(e => e.Jugador)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Jugador>()
                .HasMany(e => e.Jugador_Equipo)
                .WithRequired(e => e.Jugador)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Jugador>()
                .HasMany(e => e.Reserva)
                .WithRequired(e => e.Jugador)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Localidad>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Localidad>()
                .HasMany(e => e.Domicilio)
                .WithRequired(e => e.Localidad)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Partido>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Partido>()
                .HasMany(e => e.Localidad)
                .WithRequired(e => e.Partido)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Permiso>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Permiso>()
                .HasMany(e => e.Rol_Permiso)
                .WithRequired(e => e.Permiso)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Precio>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Precio>()
                .HasMany(e => e.Precio_Cancha)
                .WithRequired(e => e.Precio)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Predio>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Predio>()
                .HasMany(e => e.Cancha)
                .WithRequired(e => e.Predio)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Predio>()
                .HasMany(e => e.Predio_Calificacion)
                .WithRequired(e => e.Predio)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Provincia>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Reserva>()
                .HasMany(e => e.Cancelaciones)
                .WithRequired(e => e.Reserva)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Rol>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Rol>()
                .HasMany(e => e.Administrador)
                .WithRequired(e => e.Rol)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Rol>()
                .HasMany(e => e.Rol_Permiso)
                .WithRequired(e => e.Rol)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Rol>()
                .HasMany(e => e.Usuario)
                .WithRequired(e => e.Rol)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Suelo>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Suelo>()
                .HasMany(e => e.Cancha)
                .WithRequired(e => e.Suelo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Apellido)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.CorreoElectronico)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Usuario_Calificacion)
                .WithRequired(e => e.Usuario)
                .WillCascadeOnDelete(false);
        }
    }
}
