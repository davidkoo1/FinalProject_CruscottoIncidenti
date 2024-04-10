using Application.DTO;
using Application.Validator;
using FluentValidation;
using FluentValidation.AspNetCore;
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
            //Added fluent validation
            services.AddControllers().AddFluentValidation(options =>
            {
                //Automatic registration of validators in assembly
                options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
                //options.RegisterValidatorsFromAssemblyContaining<Program>();
                options.LocalizationEnabled = true;
            });


            services.AddTransient<IValidator<LoginDto>, LoginDtoValidator>();
            services.AddTransient<IValidator<UpsertUserDto>, UpsertUserDtoValidator>();

            //AutoMapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            return services;
        }
    }
}
