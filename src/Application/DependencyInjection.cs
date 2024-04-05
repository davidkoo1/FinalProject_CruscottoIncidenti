using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{

    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            //FluentValidation

            //AutoMapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());



            return services;
        }
    }
}
