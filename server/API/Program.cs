using System.Text.Json;
using api;
using DefaultNamespace;
using efscaffold.Entities;
using Infrastructure.Postgres.Scaffolding;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

var appoptions = builder.Services.AddAppOptions(builder.Configuration);

Console.WriteLine(JsonSerializer.Serialize(appoptions));

builder.Services.AddDbContext<MyDbContext>(conf =>
{
    conf.UseNpgsql(appoptions.DbConnectionString);
});


var app = builder.Build();
app.MapGet("/", (
    
    [FromServices]IOptionsMonitor<AppOptions> optionMonitor,
    [FromServices]MyDbContext dbContext) =>
{
    var myFlower = new Flowersystem()
    {
        Title = "flowername",
        Id = "flowerId",
        Description = "isBigFlower"
    };
    dbContext.Flowersystems.Add(myFlower);
    dbContext.SaveChanges();
    var objects = dbContext.Flowersystems.ToList();
    return objects;
    
} );

app.Run();
