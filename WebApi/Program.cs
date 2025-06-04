using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using static Domain.Tasks;
using Microsoft.FSharp.Core;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
var services = builder.Services;

services.AddSingleton<ITaskStorage, TaskStorage>();

var app = builder.Build();
app.UseRouting();
app.MapGet("/add",
    (
        [FromQuery] string name,
        [FromQuery] string desc,
        [FromServices] ITaskStorage storage
    ) =>
    {
        Save(storage, name, desc);
    });
app.MapGet("/find",
    (
        [FromQuery] string name,
        [FromServices] ITaskStorage storage
    ) =>
    {
        var option = Find(storage, name);
        return FSharpOption<MyTask>.get_IsSome(option) 
            ? option.Value 
            : null;
    });
app.Run();