using Microsoft.Extensions.DependencyInjection.Extensions;
using Store.Management.Application.Interfaces;
using Store.Management.Application.Services;
using Store.Management.Domain.Interfaces;
using Store.Management.Infrastructure.Data.Context;
using Store.Management.Infrastructure.Data.Repositories;
using System.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DatabaseContext>();

builder.Services.TryAddScoped<IServiceCategory, ServiceCategory>();
builder.Services.TryAddScoped<IRepositoryCategory, RepositoryCategory>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("https://localhost:3001")
              .AllowAnyMethod()
              .AllowAnyHeader()
              .AllowCredentials();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();