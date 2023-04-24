namespace SquidAdminPanel.Api.Application;

public static class AppMiddlewaresRegister
{
    public static void RegisterMiddleware(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        var apis = app.Services.GetServices<IApi>().ToList();
        apis.ForEach(api => api.Register(app));
    }
}
