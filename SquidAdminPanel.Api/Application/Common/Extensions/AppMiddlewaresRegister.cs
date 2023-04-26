using SquidAdminPanel.Api.Application.Middleware;

namespace SquidAdminPanel.Api.Application;

public static class AppMiddlewaresRegister
{
    public static void RegisterMiddleware(this WebApplication app)
    {
        app.UseMiddleware<ExceptionHandlerMiddleware>();
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        var apis = app.Services.GetServices<IApi>().ToList();
        apis.ForEach(api => api.Register(app));

        app.UseCors("MyCors");
    }
}
