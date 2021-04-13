using Template.Business.Interfaces;
using Template.Business.Notificacoes;
using Template.Business.Services;
using Template.Data.Context;
using Template.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Template.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<TemplateDbContext>();
            services.AddScoped<IEventoRepository, EventoRepository>();
            services.AddScoped<IEventoService, EventoService>();
            services.AddScoped<ISensorRepository, SensorRepository>();
            services.AddScoped<ISensorService, SensorService>();
            services.AddScoped<INotificador, Notificador>();
            return services;
        }
    }
}
