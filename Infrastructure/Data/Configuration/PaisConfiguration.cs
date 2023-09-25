using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class PaisConfiguration : IEntityTypeConfiguration<Pais>
    {
        public void Configure(EntityTypeBuilder<Pais> builder)
        {
            // Nombre de la tabla
            builder.ToTable("Pais");
            
            // Llave primaria y definicion de la propiedad o atributo
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).IsRequired().HasMaxLength(3);

            // Definicion de la propiedad o atributo
            builder.Property(p => p.Nombre).IsRequired().HasColumnName("Nombre").HasColumnType("varchar").HasMaxLength(30);
        }
    }
}