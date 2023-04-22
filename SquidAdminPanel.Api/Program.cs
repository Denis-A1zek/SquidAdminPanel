using SquidAdminPanel.Api.Api.Interfaces;
using SquidAdminPanel.Api.Common.Extensions;
using SquidAdminPanel.Api.Data;

//Application builder
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddServices();

//App builder
var app = builder.Build();
app.RegisterMiddleware();

//Register api 
var apis = app.Services.GetServices<IApi>().ToList();
apis.ForEach(api => api.Register(app));

var context = new FileContext("some.text");
//var res = await context.Query<List<int>>(() =>
//{
//    return new List<int> { 1, 2, 3, 4, 5, 6 };
//}, res =>
//{
//    res.Add(1);
//});

//Start app
app.Run();
