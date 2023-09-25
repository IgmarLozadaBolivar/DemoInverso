using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class TipoDocumentoConfiguration : IEntityTypeConfiguration<TipoDocumento>
    {
        public void Configure(EntityTypeBuilder<TipoDocumento> builder)
        {
            // Nombre de la tabla
            builder.ToTable("Tipo Documento");

            // Llave primaria y definicion de la propiedad o atributo
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).IsRequired().HasMaxLength(3);

            // Definicion de la propiedad o atributo
            builder.Property(c => c.Nombre).IsRequired().HasColumnName("Nombre").HasColumnType("varchar").HasMaxLength(30);
            
            // Definicion de la propiedad o atributo
            builder.Property(c => c.Abreviatura).IsRequired().HasColumnName("Abreviatura").HasColumnType("varchar").HasMaxLength(3);

            // Definicion de la propiedad o atributo
            builder.Property(c => c.Descripcion).IsRequired().HasColumnName("Descripcion").HasColumnType("varchar").HasMaxLength(15);
        }
    }
}