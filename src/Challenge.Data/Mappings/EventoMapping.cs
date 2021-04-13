using Template.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Template.Data.Mappings
{
    public class EventoMapping : IEntityTypeConfiguration<Evento>
    {
        public void Configure(EntityTypeBuilder<Evento> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(c => c.Valor)
                .HasColumnType("numeric(10,5)")
                .IsRequired();
            builder.Property(c => c.Tempo)
              .HasColumnType("datetime");

            builder.ToTable("Eventos");
        }
    }
}
