using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Project.WebApi.Validators.RequestModels;

namespace Project.WebApi.DependencyResolvers
{
    public static class FluentValidationResolver
    {
        public static void AddFluentValidationService(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation();
            services.AddFluentValidationClientsideAdapters();
            services.AddValidatorsFromAssemblyContaining<CreateCategoryRequestModelValidator>();
        }
    }
}

