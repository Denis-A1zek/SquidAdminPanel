using SquidAdminPanel.Api.Application;

namespace SquidAdminPanel.Api.Application;

public class TestApi : IApi
{
    public void Register(WebApplication app)
    {
        app.MapGet("/", () => new { message = "Hello world" });
    }
}
