using Application.Common.Interfaces;
using Application.Common.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{

    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            //FluentValidation

            //AutoMapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //Repos
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
