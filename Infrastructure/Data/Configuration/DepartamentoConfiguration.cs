using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class DepartamentoConfiguration : IEntityTypeConfiguration<Departamento>
    {
        public void Configure(EntityTypeBuilder<Departamento> builder)
        {
            // Nombre de la tabla
            builder.ToTable("Departamento");

            // Llave primaria y definicion de la propiedad o atributo
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Id).IsRequired().HasMaxLength(3);

            // Definicion de la propiedad o atributo
            builder.Property(d => d.Nombre).IsRequired().HasColumnName("Nombre").HasColumnType("varchar").HasMaxLength(30);

            // Llave foranea
            builder.HasOne(p => p.Pais).WithMany(p => p.Departamentos).HasForeignKey(p => p.IdPaisFK);
        }
    }
}