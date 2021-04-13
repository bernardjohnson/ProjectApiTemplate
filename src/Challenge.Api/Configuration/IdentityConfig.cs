using System.Text;
using Template.Api.Data;
using Template.Api.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Template.Api.Configuration
{
    public static class IdentityConfig
    {
        public static IServiceCollection AddIdentityConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApiDbContext>(options =>
              options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<ApiDbContext>()
                .AddDefaultTokenProviders();

            var appSettings = configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettings);

            var appSettingsGet = appSettings.Get<AppSettings>();
            var chave = Encoding.ASCII.GetBytes(appSettingsGet.Secret);

            services.AddAuthentication(x =>
           {
               x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
               x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
           }).AddJwtBearer(x =>
           {
               x.RequireHttpsMetadata = true;
               x.SaveToken = true;
               x.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateIssuerSigningKey = true,
                   IssuerSigningKey = new SymmetricSecurityKey(chave),
                   ValidateIssuer = true,
                   ValidAudience = appSettingsGet.ValidoEm,
                   ValidIssuer = appSettingsGet.Emissor
               };
           });

            return services;
        }
    }
}
