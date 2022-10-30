using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uibasoft.Domain.CustomEntities;
using Uibasoft.Domain.DTOs.Modulos.Seguridad.Usuarios;
using Uibasoft.Domain.Interfaces;
using Uibasoft.Domain.Services;

namespace Uibasoft.DataAccess.Extensions
{
    public static class ServiceCollectionExtension
    {
        private static IDictionary<string, UsuarioDto> _users = new Dictionary<string, UsuarioDto>
        {
            {
                "lbaigorria", new UsuarioDto {
                    Id =  Guid.NewGuid(),
                    UniqueCode = 1,
                    Username = "lbaigorria",
                    Password = "1",
                    Email = "lbaigorria@farmacorp.com",
                    Nombres = "Alberto",
                    Apellidos = "Farmacorp",
                    FechaCreacionUtc = DateTime.UtcNow,
                    KeyRoles = new List<string>() { "admin", "admin-microerp" }
                }
            },
            {
                "uialberto", new UsuarioDto {
                    Id =  Guid.NewGuid(),
                    UniqueCode = 2,
                    Username = "uialberto",
                    Password = "2",
                    Email = "uialberto@gmail.com",
                    Nombres = "Alberto",
                    Apellidos = "Baigorria",
                    FechaCreacionUtc = DateTime.UtcNow,
                    KeyRoles = new List<string>() { "admin-microerp" }
                }
            },
            {
                "lfigueroa", new UsuarioDto {
                    Id =  Guid.NewGuid(),
                    UniqueCode = 3,
                    Username = "lfigueroa",
                    Password = "1",
                    Email = "lfigueroa@farmacorp.com",
                    Nombres = "Alberto",
                    Apellidos = "Figueroa",
                    FechaCreacionUtc = DateTime.UtcNow,
                    KeyRoles = new List<string>() { "admin-microerp" }
                }
            }
        };

        public static IServiceCollection AddOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AppSettingsConfigOptions>(options => configuration.GetSection("AppSettingsConfig").Bind(options));
            services.Configure<AppPronosSettingsConfigOptions>(options => configuration.GetSection("AppPronosSettingsConfigOptions").Bind(options));
            return services;
        }
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(_users);
            services.AddScoped<ITokenAppService, TokenAppService>();

            //services.AddScoped(typeof(IAppContextBase<>), typeof(AppContextBase<>));
            //services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            //services.AddScoped(typeof(IAppService<>), typeof(AppService<>));

            //services.AddSingleton<IRabbitPersistentConnection>(provider =>
            //{
            //    var logger = provider.GetRequiredService<ILogger<RabbitPersistentConnection>>();
            //    var appSettings = provider.GetRequiredService<IOptions<AppSettingsConfigOptions>>().Value;
            //    string host = appSettings?.BrokerSetting?.HostName;
            //    string username = appSettings?.BrokerSetting?.UserName;
            //    string password = appSettings?.BrokerSetting?.Password;
            //    string virtualhost = appSettings?.BrokerSetting?.VirtualHost;
            //    int port = appSettings?.BrokerSetting?.Port ?? 0;
            //    return new RabbitPersistentConnection(logger, host, username, password, virtualhost, port, 1);
            //});


            //services.AddScoped<IRepoParametros, RepoParametros>();
            //services.AddScoped<IServiceParametros, ServiceParametros>();
            services.AddScoped<IServiceLogin, ServiceLogin>();
            //services.AddScoped<IParametroAppService, ParametroAppService>();

            //services.AddTransient<ISecurityService, SecurityService>();
            //services.AddSingleton<IPasswordService, PasswordService>();
            //services.AddSingleton<IUriService>(provider =>
            //{
            //    var accesor = provider.GetRequiredService<IHttpContextAccessor>();
            //    var request = accesor.HttpContext.Request;
            //    var absoluteUri = string.Concat(request.Scheme, "://", request.Host.ToUriComponent());
            //    return new UriService(absoluteUri);
            //});

            return services;
        }

    }
}
