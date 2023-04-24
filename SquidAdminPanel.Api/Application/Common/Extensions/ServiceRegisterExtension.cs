﻿using SquidAdminPanel.Api.Application;
using SquidAdminPanel.Api.Core.Processes.Base;
using SquidAdminPanel.Api.Data;
using System.Diagnostics;
using System.Reflection;
using System.Security.Cryptography;

namespace SquidAdminPanel.Api.Application;

public static class ServiceRegisterExtension
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddTransient<IApi, TestApi>();
        Assembly.GetAssembly(typeof(ProcessManager))
                .GetTypes().Where(type => type.IsSubclassOf(typeof(ProcessManager)))
                .ToList().ForEach(type =>
                {
                    services.AddScoped(type);
                }); ;

        services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
    }
}

