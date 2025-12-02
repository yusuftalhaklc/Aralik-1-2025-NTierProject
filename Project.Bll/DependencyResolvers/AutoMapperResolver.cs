using Microsoft.Extensions.DependencyInjection;
using Project.Bll.AutoMapper;


namespace Project.Bll.DependencyResolvers
{
    public static class AutoMapperResolver
    {
        public static void AddAutoMapperService(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(DtoMappingProfile));
        }
    }
}
