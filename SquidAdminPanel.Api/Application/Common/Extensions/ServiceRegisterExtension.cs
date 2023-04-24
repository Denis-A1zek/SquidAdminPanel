using SquidAdminPanel.Api.Application;
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
        services.AddTransient<IApi, TestApi>();
        services.AddTransient<IApi, UserApi>();

        Assembly.GetAssembly(typeof(ProcessManager))
                .GetTypes().Where(type => type.IsSubclassOf(typeof(ProcessManager)))
                .ToList().ForEach(type =>
                {
                    services.AddScoped(type);
                });

        services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        services.AddScoped<UserContext>(factory =>
        {
            return new UserContext(configuration[nameof(UserContext)]);
        });
    }
}

