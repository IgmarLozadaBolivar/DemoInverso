using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class CiudadConfiguration : IEntityTypeConfiguration<Ciudad>
    {
        public void Configure(EntityTypeBuilder<Ciudad> builder)
        {
            // Nombre de la tabla
            builder.ToTable("Ciudad");

            // Llave primaria y definicion de la propiedad o atributo
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).IsRequired().HasMaxLength(3);

            // Definicion de la propiedad o atributo
            builder.Property(c => c.Nombre).IsRequired().HasColumnName("Nombre").HasColumnType("varchar").HasMaxLength(30);

            // Llave foranea
            builder.HasOne(p => p.Departamento).WithMany(p => p.Ciudades).HasForeignKey(p => p.IdDepFK);
        }
    }
}