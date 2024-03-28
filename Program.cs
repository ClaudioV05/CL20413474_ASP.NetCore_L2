using System.Net.Http.Headers;
using System.Runtime;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient("StoreManagement", config =>
{
    config.DefaultRequestHeaders.Clear();
    //config.DefaultRequestHeaders.Add("User-Agent", string.Empty);
    //config.DefaultRequestHeaders.Add("Authorization", string.Empty);
    config.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    config.BaseAddress = new Uri(builder?.Configuration["Uri:StoreManagementApi"]);
    config.Timeout = new TimeSpan(0, 0, 10);
});


// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();