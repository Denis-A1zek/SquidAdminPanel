namespace SquidAdminPanel.Api.Common.Extensions;

public static class AppMiddlewaresRegister
{
    public static void RegisterMiddleware(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
    }
}
