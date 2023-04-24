using SquidAdminPanel.Api.Application;
using SquidAdminPanel.Api.Data;

namespace SquidAdminPanel.Api.Application;

public static class ServiceRegisterExtension
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddTransient<IApi, TestApi>();

    }
}
