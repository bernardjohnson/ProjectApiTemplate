using Template.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Template.Data.Mappings
{
    public class SensorMapping : IEntityTypeConfiguration<Sensor>
    {
        public void Configure(EntityTypeBuilder<Sensor> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(c => c.Nome)
                  .HasColumnType("varchar(150)");
            builder.Property(c => c.Pais)
               .HasColumnType("varchar(50)");
            builder.Property(c => c.Regiao)
                  .HasColumnType("varchar(50)");

            builder.HasMany(f => f.Eventos)
             .WithOne(p => p.Sensor)
             .HasForeignKey(p => p.SensorId);

            builder.ToTable("Sensores");

        }
    }
}
