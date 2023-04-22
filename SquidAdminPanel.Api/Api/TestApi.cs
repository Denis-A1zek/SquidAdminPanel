using SquidAdminPanel.Api.Api.Interfaces;

namespace SquidAdminPanel.Api.Api;

public class TestApi : IApi
{
    public void Register(WebApplication app)
    {
        app.MapGet("/", () => new { message = "Hello world" });
    }
}
