using System;
using APIParaConsumir.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace APIParaConsumir.Data
{
    public partial class BibliotecasContext : DbContext
    {
        public BibliotecasContext()
        {
        }

        public BibliotecasContext(DbContextOptions<BibliotecasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Biblioteca> Bibliotecas { get; set; }
        public virtual DbSet<Bibliotecaria> Bibliotecaria { get; set; }
        public virtual DbSet<Libro> Libros { get; set; }

   

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Biblioteca>(entity =>
            {
                entity.HasKey(e => e.IdBiblioteca)
                    .HasName("PK__bibliote__1EEBBDFE38AAB437");

                entity.ToTable("biblioteca");

                entity.Property(e => e.IdBiblioteca).HasColumnName("id_biblioteca");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("direccion");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Bibliotecaria>(entity =>
            {
                entity.HasKey(e => e.IdBibliotecaria)
                    .HasName("PK__bibliote__62F27BDCDFACD455");

                entity.ToTable("bibliotecaria");

                entity.Property(e => e.IdBibliotecaria).HasColumnName("id_bibliotecaria");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("apellido");

                entity.Property(e => e.IdBiblioteca).HasColumnName("id_biblioteca");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.HasOne(d => d.IdBibliotecaNavigation)
                    .WithMany(p => p.Bibliotecaria)
                    .HasForeignKey(d => d.IdBiblioteca)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_bibliotecaria_biblioteca");
            });

            modelBuilder.Entity<Libro>(entity =>
            {
                entity.ToTable("libro");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.IdBibliotecaria).HasColumnName("id_bibliotecaria");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.HasOne(d => d.IdBibliotecariaNavigation)
                    .WithMany(p => p.Libros)
                    .HasForeignKey(d => d.IdBibliotecaria)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_libro_bibliotecaria");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
