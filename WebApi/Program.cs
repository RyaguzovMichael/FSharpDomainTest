var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
var services = builder.Services;

var app = builder.Build();
app.UseRouting();
app.MapGet("/", () => "Hello World!");
app.Run();