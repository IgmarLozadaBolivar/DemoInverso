using System;
using System.Collections.Generic;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public partial class DemoContext : DbContext
{
    public DemoContext()
    {
    }

    public DemoContext(DbContextOptions<DemoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Ciudad> Ciudads { get; set; }

    public virtual DbSet<Departamento> Departamentos { get; set; }

    public virtual DbSet<EfmigrationsHistory> EfmigrationsHistories { get; set; }

    public virtual DbSet<Pai> Pais { get; set; }

    public virtual DbSet<Persona> Personas { get; set; }

    public virtual DbSet<TipoDocumento> TipoDocumentos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;user=root;password=1122809631;database=DemoDB", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.1.0-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Ciudad>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Ciudad");

            entity.HasIndex(e => e.IdDepFk, "IX_Ciudad_IdDepFK");

            entity.Property(e => e.IdDepFk).HasColumnName("IdDepFK");
            entity.Property(e => e.Nombre).HasMaxLength(30);

            entity.HasOne(d => d.IdDepFkNavigation).WithMany(p => p.Ciudads).HasForeignKey(d => d.IdDepFk);
        });

        modelBuilder.Entity<Departamento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Departamento");

            entity.HasIndex(e => e.IdPaisFk, "IX_Departamento_IdPaisFK");

            entity.Property(e => e.IdPaisFk).HasColumnName("IdPaisFK");
            entity.Property(e => e.Nombre).HasMaxLength(30);

            entity.HasOne(d => d.IdPaisFkNavigation).WithMany(p => p.Departamentos).HasForeignKey(d => d.IdPaisFk);
        });

        modelBuilder.Entity<EfmigrationsHistory>(entity =>
        {
            entity.HasKey(e => e.MigrationId).HasName("PRIMARY");

            entity.ToTable("__EFMigrationsHistory");

            entity.Property(e => e.MigrationId).HasMaxLength(150);
            entity.Property(e => e.ProductVersion).HasMaxLength(32);
        });

        modelBuilder.Entity<Pai>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Nombre).HasMaxLength(30);
        });

        modelBuilder.Entity<Persona>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Persona");

            entity.HasIndex(e => e.IdCiuFk, "IX_Persona_IdCiuFK");

            entity.HasIndex(e => e.IdTipoDoc, "IX_Persona_IdTipoDoc");

            entity.Property(e => e.Apellido).HasMaxLength(30);
            entity.Property(e => e.FechaNacimiento).HasColumnName("Fecha Nacimiento");
            entity.Property(e => e.IdCiuFk).HasColumnName("IdCiuFK");
            entity.Property(e => e.Nombre).HasMaxLength(30);

            entity.HasOne(d => d.IdCiuFkNavigation).WithMany(p => p.Personas).HasForeignKey(d => d.IdCiuFk);

            entity.HasOne(d => d.IdTipoDocNavigation).WithMany(p => p.Personas).HasForeignKey(d => d.IdTipoDoc);
        });

        modelBuilder.Entity<TipoDocumento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Tipo Documento");

            entity.Property(e => e.Abreviatura).HasMaxLength(3);
            entity.Property(e => e.Descripcion).HasMaxLength(15);
            entity.Property(e => e.Nombre).HasMaxLength(30);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
