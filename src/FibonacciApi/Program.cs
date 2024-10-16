using FibonacciApi.Application;
using FibonacciApi.Application.FibonacciSequence.FibonacciSequence.Interfaces;
using FibonacciApi.Infrastructure;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<GlobalExceptionHandlerMiddleware>();
builder.Services.AddTransient<LogRequestMiddleware>();
builder.Services.AddHealthChecks();

builder.Services.AddFibonacciServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<GlobalExceptionHandlerMiddleware>();
app.UseMiddleware<LogRequestMiddleware>();

app.MapHealthChecks("/hc", new HealthCheckOptions
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse,
    Predicate = _ => false
});

app.MapGet("/fibonacci-nth/{number}", ([FromServices]IGetNthNumber getNthNumber, int number) =>
{
    return getNthNumber.Handle(number);
})
.WithName("FibonacciApi")
.WithOpenApi();

app.Run();
