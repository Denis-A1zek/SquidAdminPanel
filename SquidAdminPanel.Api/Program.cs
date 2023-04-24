using SquidAdminPanel.Api.Application;
using SquidAdminPanel.Api.Data;

//Application builder
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddServices();

//App builder
var app = builder.Build();
app.RegisterMiddleware();

//Start app
app.Run();
