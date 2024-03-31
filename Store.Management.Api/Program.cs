using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Store.Management.Application.Interfaces;
using Store.Management.Application.Services;
using Store.Management.Domain.Interfaces;
using Store.Management.Infrastructure.Data.Context;
using Store.Management.Infrastructure.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#region Adding the context.

builder.Services.AddDbContext<DatabaseContext>();

#endregion Adding the context.

#region Adding the AspNet Core identity.

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 8;
    options.Password.RequiredUniqueChars = 3;
}).AddEntityFrameworkStores<DatabaseContext>();

#endregion Adding the AspNet Core identity.

#region Adding the services to product.

builder.Services.TryAddScoped<IServiceProduct, ServiceProduct>();
builder.Services.TryAddScoped<IRepositoryProduct, RepositoryProduct>();

#endregion  Adding the services to product.

#region Adding the services to category.

builder.Services.TryAddScoped<IServiceCategory, ServiceCategory>();
builder.Services.TryAddScoped<IRepositoryCategory, RepositoryCategory>();

#endregion Adding the services to category.

#region Adding the services to sub category.

builder.Services.TryAddScoped<IServiceSubCategory, ServiceSubCategory>();
builder.Services.TryAddScoped<IRepositorySubCategory, RepositorySubCategory>();

#endregion Adding the services to sub category.

#region Adding the services to user.

builder.Services.TryAddScoped<IServiceUser, ServiceUser>();
builder.Services.TryAddScoped<IRepositoryUser, RepositoryUser>();

#endregion Adding the services to user.

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
    app.UseSwaggerUI(options =>
    {
        options.EnableTryItOutByDefault();
    });
}

app.UseCors();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();