using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Municipalidad.Abastecimiento.WebAPI.Models
{
    public partial class MunicipalidadLaredoContext : DbContext
    {
        public MunicipalidadLaredoContext()
        {
        }

        public MunicipalidadLaredoContext(DbContextOptions<MunicipalidadLaredoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Area> Areas { get; set; } = null!;
        public virtual DbSet<Estado> Estados { get; set; } = null!;
        public virtual DbSet<Orden> Ordenes { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Area>(entity =>
            {
                entity.Property(e => e.Encargado).HasMaxLength(100);

                entity.Property(e => e.Nombre).HasMaxLength(100);
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.Property(e => e.Color).HasMaxLength(6);

                entity.Property(e => e.Nombre).HasMaxLength(50);
            });

            modelBuilder.Entity<Orden>(entity =>
            {
                entity.Property(e => e.FechaCreacion).HasColumnType("date");

                entity.Property(e => e.FechaModificacion).HasColumnType("date");

                entity.Property(e => e.Observaciones).HasMaxLength(500);

                entity.HasOne(d => d.AreaSolicitante)
                    .WithMany(p => p.Ordenes)
                    .HasForeignKey(d => d.AreaSolicitanteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Solicitudes_Areas");

                entity.HasOne(d => d.Estado)
                    .WithMany(p => p.Ordenes)
                    .HasForeignKey(d => d.EstadoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Solicitudes_Estados");

                entity.HasOne(d => d.Producto)
                    .WithMany(p => p.Ordenes)
                    .HasForeignKey(d => d.ProductoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Solicitudes_Productos");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.Property(e => e.Descripcion).HasMaxLength(100);

                entity.Property(e => e.Nombre).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
