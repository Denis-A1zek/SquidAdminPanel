using SquidAdminPanel.Api.Api.Interfaces;
using SquidAdminPanel.Api.Extensions;

//Application builder
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddServices();

//App builder
var app = builder.Build();
app.RegisterMiddleware();

//Register api 
var apis = app.Services.GetServices<IApi>().ToList();
apis.ForEach(api => api.Register(app)); 

//Start app
app.Run();
