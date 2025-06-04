using Domain;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
var services = builder.Services;

services.AddSingleton<Tasks.ITaskStorage, TaskStorage>();

var app = builder.Build();
app.UseRouting();
app.MapGet("/add",
    ([FromQuery] string name, [FromQuery] string desc,
        [FromServices] Tasks.ITaskStorage storage) =>
    {
        Tasks.Save(storage, name, desc);
    });
app.MapGet("/find",
    ([FromQuery] string name, [FromServices] Tasks.ITaskStorage storage) =>
        Tasks.Find(storage, name));
app.Run();