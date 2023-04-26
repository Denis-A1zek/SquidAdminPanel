using FluentValidation;
using MediatR;
using SquidAdminPanel.Api.Application;
using SquidAdminPanel.Api.Application.Cache;
using SquidAdminPanel.Api.Core.Behaviors;
using SquidAdminPanel.Api.Core.Helpers;
using SquidAdminPanel.Api.Core.Interfaces;
using SquidAdminPanel.Api.Core.Processes.Base;
using SquidAdminPanel.Api.Data;
using System.Diagnostics;
using System.Reflection;
using System.Security.Cryptography;

namespace SquidAdminPanel.Api.Application;

public static class ServiceRegisterExtension
{
    public static void AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        //TO-DO Get all classes from assembley with interface IApi and inject into services
        services.AddTransient<IApi, UserApi>();
        services.AddTransient<IApi, LogApi>();

        Assembly.GetAssembly(typeof(ProcessManager))
                .GetTypes().Where(type => type.IsSubclassOf(typeof(ProcessManager)))
                .ToList().ForEach(type =>
                {
                    services.AddScoped(type);
                });

        services.AddSingleton<IGlobalCacheMemory,GlobalCacheMemory>();
        services.AddScoped<ILogReader, LogReader>();
        services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddValidatorsFromAssemblies(new[] {Assembly.GetExecutingAssembly()});  
        services.AddTransient(typeof(IPipelineBehavior<,>),
            typeof(ValidationBehavior<,>));

        services.AddCors(options => options.AddPolicy(name: "MyCors",
        policy =>
        {
            policy.WithOrigins("https://192.168.1.102:80").AllowAnyMethod().AllowAnyHeader().AllowCredentials();
            policy.WithOrigins("http://localhost:5500").AllowAnyMethod().AllowAnyHeader().AllowCredentials();
            policy.WithOrigins("http://127.0.0.1:5500").AllowAnyMethod().AllowAnyHeader().AllowCredentials();
            policy.WithOrigins("https://192.168.1.102/").AllowAnyMethod().AllowAnyHeader().AllowCredentials();
            policy.WithOrigins("https://192.168.1.102").AllowAnyMethod().AllowAnyHeader().AllowCredentials();
        }));


        services.AddScoped<UserContext>(factory =>
        {
            return new UserContext(configuration[nameof(UserContext)]);
        });

        services.AddScoped<LogsContext>(factory =>
        {
            return new LogsContext(configuration[nameof(LogsContext)]);
        });
    }
}

