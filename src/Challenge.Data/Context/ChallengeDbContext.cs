using Template.Business.Models;
using Microsoft.EntityFrameworkCore;

namespace Template.Data.Context
{
    public class TemplateDbContext : DbContext
    {
        public TemplateDbContext(DbContextOptions<TemplateDbContext> options) : base(options) { }

        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Sensor> Sensores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TemplateDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
