using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace _1998YIUL0801199901278.Models
{
    public partial class AtlantidaContext : DbContext
    {
        public AtlantidaContext()
        {
        }

        public AtlantidaContext(DbContextOptions<AtlantidaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ciudad> Ciudads { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Cuentum> Cuenta { get; set; }
        public virtual DbSet<Departamento> Departamentos { get; set; }
        public virtual DbSet<Estado> Estados { get; set; }
        public virtual DbSet<Monedum> Moneda { get; set; }
        public virtual DbSet<Pai> Pais { get; set; }
        public virtual DbSet<Profesion> Profesions { get; set; }
        public virtual DbSet<TipoCuentum> TipoCuenta { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-TNJHFEP;Database=Atlantida;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Ciudad>(entity =>
            {
                entity.ToTable("Ciudad");

                entity.Property(e => e.Ciudad1)
                    .HasMaxLength(50)
                    .HasColumnName("Ciudad");

                entity.Property(e => e.CodigoDepartamento).HasColumnName("codigo_departamento");

                entity.HasOne(d => d.CodigoDepartamentoNavigation)
                    .WithMany(p => p.Ciudads)
                    .HasForeignKey(d => d.CodigoDepartamento)
                    .HasConstraintName("FK_Ciudad_Departamento");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("Cliente");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CodigoEstado).HasColumnName("Codigo_estado");

                entity.Property(e => e.Direccion).HasMaxLength(50);

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnType("date")
                    .HasColumnName("Fecha_nacimiento");

                entity.Property(e => e.Genero)
                    .IsRequired()
                    .HasMaxLength(1)
                    .HasColumnName("genero");

                entity.Property(e => e.id_ciudad).HasColumnName("Id_ciudad");

                entity.Property(e => e.IdProfesion).HasColumnName("id_profesion");

                entity.Property(e => e.Identidad)
                    .IsRequired()
                    .HasMaxLength(13);

                entity.Property(e => e.PrimerA)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Primer_A");

                entity.Property(e => e.PrimerN)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Primer_N");

                entity.Property(e => e.SegundoA)
                    .HasMaxLength(50)
                    .HasColumnName("Segundo_A");

                entity.Property(e => e.SegundoN)
                    .HasMaxLength(50)
                    .HasColumnName("Segundo_N");

                entity.HasOne(d => d.CodigoEstadoNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.CodigoEstado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cliente_Estado");

                entity.HasOne(d => d.IdCiudadNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.id_ciudad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cliente_Ciudad");

                entity.HasOne(d => d.IdProfesionNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.IdProfesion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cliente_Profesion");
            });

            modelBuilder.Entity<Cuentum>(entity =>
            {
                entity.Property(e => e.CodigoCliente).HasColumnName("Codigo_cliente");

                entity.Property(e => e.CodigoEstado).HasColumnName("Codigo_estado");

                entity.Property(e => e.Saldo)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("saldo");

                entity.Property(e => e.TipoCuenta).HasColumnName("Tipo_cuenta");

                entity.Property(e => e.TipoMondea).HasColumnName("Tipo_mondea");

                entity.HasOne(d => d.CodigoClienteNavigation)
                    .WithMany(p => p.Cuenta)
                    .HasForeignKey(d => d.CodigoCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cuenta_Cliente");

                entity.HasOne(d => d.TipoCuentaNavigation)
                    .WithMany(p => p.Cuenta)
                    .HasForeignKey(d => d.TipoCuenta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cuenta_Tipo_Cuenta");

                entity.HasOne(d => d.TipoMondeaNavigation)
                    .WithMany(p => p.Cuenta)
                    .HasForeignKey(d => d.TipoMondea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cuenta_Moneda");
            });

            modelBuilder.Entity<Departamento>(entity =>
            {
                entity.ToTable("Departamento");

                entity.Property(e => e.CodigoPais).HasColumnName("codigo_pais");

                entity.Property(e => e.Departamento1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Departamento");

                entity.HasOne(d => d.CodigoPaisNavigation)
                    .WithMany(p => p.Departamentos)
                    .HasForeignKey(d => d.CodigoPais)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Departamento_Pais");
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.ToTable("Estado");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(1);
            });

            modelBuilder.Entity<Monedum>(entity =>
            {
                entity.Property(e => e.DescripcionMoneda)
                    .HasMaxLength(50)
                    .HasColumnName("Descripcion_moneda");
            });

            modelBuilder.Entity<Pai>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Decripcion).HasMaxLength(20);
            });

            modelBuilder.Entity<Profesion>(entity =>
            {
                entity.ToTable("Profesion");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Profesion1)
                    .HasMaxLength(50)
                    .HasColumnName("Profesion");
            });

            modelBuilder.Entity<TipoCuentum>(entity =>
            {
                entity.ToTable("Tipo_Cuenta");

                entity.Property(e => e.DescripcionCuenta)
                    .HasMaxLength(50)
                    .HasColumnName("Descripcion_cuenta");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
