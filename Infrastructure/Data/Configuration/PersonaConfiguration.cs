using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class PersonaConfiguration : IEntityTypeConfiguration<Persona>
    {
        public void Configure(EntityTypeBuilder<Persona> builder)
        {
            // Nombre de la tabla
            builder.ToTable("Persona");

            // Llave primaria y definicion de la propiedad o atributo
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).IsRequired().HasMaxLength(3);

            // Definicion de la propiedad o atributo
            builder.Property(c => c.Nombre).IsRequired().HasColumnName("Nombre").HasColumnType("varchar").HasMaxLength(30);
            
            // Definicion de la propiedad o atributo
            builder.Property(c => c.Apellido).IsRequired().HasColumnName("Apellido").HasColumnType("varchar").HasMaxLength(30);

            // Definicion de la propiedad o atributo
            builder.Property(c => c.FechaNac).IsRequired().HasColumnName("Fecha Nacimiento").HasColumnType("Date").HasMaxLength(30);

            // Definicion de la propiedad o atributo
            builder.Property(c => c.Edad).IsRequired().HasColumnName("Edad").HasColumnType("int").HasMaxLength(3);

            // Llave foranea
            builder.HasOne(p => p.Ciudad).WithMany(p => p.Personas).HasForeignKey(p => p.IdCiuFK);

            // Llave foranea
            builder.HasOne(p => p.TipoDocumento).WithMany(p => p.Personas).HasForeignKey(p => p.IdTipoDoc);
        }
    }
}