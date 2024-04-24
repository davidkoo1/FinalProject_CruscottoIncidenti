using Application.Common.Interfaces;
using Application.Common.Services;
using Application.DTO;
using Application.Validator;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System.Reflection;

namespace Application
{

    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            //FluentValidation
            services.AddControllers().AddFluentValidation(options =>
            {
                //Automatic registration of validators in assembly
                options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
                //options.RegisterValidatorsFromAssemblyContaining<Program>();
                options.LocalizationEnabled = true;
            });


            services.AddTransient<IValidator<LoginDto>, LoginDtoValidator>();
            services.AddTransient<IValidator<UpsertUserDto>, UpsertUserDtoValidator>();
            services.AddTransient<IValidator<UpsertIncidentDto>, UpsertIncidentDtoValidator>();

            services.AddTransient<IFileService, FileService>();

            //AutoMapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //Logger
            Log.Logger = new LoggerConfiguration()
                //.MinimumLevel.Debug()
                .WriteTo.Console()
                .MinimumLevel.Information()
                .WriteTo.File(@"Logs\Logging-log.log",
                              rollingInterval: RollingInterval.Day,
                              retainedFileCountLimit: 30,
                              retainedFileTimeLimit: TimeSpan.FromDays(30))
                .CreateLogger();


            return services;
        }
    }
}
