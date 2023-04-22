using SquidAdminPanel.Api.Api;
using SquidAdminPanel.Api.Api.Interfaces;

namespace SquidAdminPanel.Api.Common.Extensions;

public static class ServiceRegisterExtension
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddTransient<IApi, TestApi>();
    }
}
