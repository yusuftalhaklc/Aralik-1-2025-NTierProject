using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Project.Dal.Context;

namespace Project.Bll.DependencyResolvers
{
    public static class DbContextResolver
    {
        public static void AddDbContextService(this IServiceCollection services)
        {
            ServiceProvider provider = services.BuildServiceProvider();

            IConfiguration configuration = provider.GetRequiredService<IConfiguration>();

            services.AddDbContext<AppDbContext>(opt => 
            opt
            .UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
            .UseLazyLoadingProxies()
            );
        }
    }
}
