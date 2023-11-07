using InternetShop.Data.Context;
using InternetShop.Service;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;

namespace InternetShop.Api.Utils
{
    public static class CoreModule
    {
        public static IServiceCollection AddCore(this IServiceCollection services, IConfiguration configuration)
        {
            services.Scan(x => x
                .FromAssembliesOf(typeof(IRequestHandler<>))
                .AddClasses(c => c.AssignableTo(typeof(IRequestHandler<,>)))
                    .AsImplementedInterfaces()
                    .WithTransientLifetime()
                .AddClasses(c => c.AssignableTo(typeof(IRequestHandler<>)))
                    .AsImplementedInterfaces()
                    .WithTransientLifetime());

            services.AddDbContext<InternetShopDbContext>(options => options
                           .UseSqlServer(configuration.GetConnectionString("ShopConnection")));

            return services;
        }
    }
}
