using VentasDale.Core.Implementations;
using VentasDale.Core.Interfaces;
using VentasDale.Persistence.Implementations;
using VentasDale.Persistence.Interfaces;

namespace VentasDale.Api.Configurations
{
    public static class AppInterfacesInjection
    {
        public static IServiceCollection AddInterfacesInjection(this IServiceCollection services)
        {
            #region Core
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IProductoService, ProductoService>();
            services.AddScoped<IVentaService, VentaService>();
            #endregion

            #region Persistence
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IProductoRepository, ProductoRepository>();
            services.AddScoped<IVentaRepository, VentaRepository>();
            #endregion
            return services;
        }
    }
}
