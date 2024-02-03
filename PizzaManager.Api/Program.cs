using Microsoft.EntityFrameworkCore;

using PizzaManager.Api.Extensions;
using PizzaManager.Business.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddBusinessServices(dbContextOptionsBuilder => dbContextOptionsBuilder.UseSqlite(@"Data Source=c:\Temp\PM.db;"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPizzasEndpoints();
app.MapIngredientsEndpoints();
app.MapPatesEndpoints();

app.Run();