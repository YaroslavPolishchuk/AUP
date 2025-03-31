
using DB_Layer.Abstract;
using DB_Layer.AppContext;
using DB_Layer.Models;
using DB_Layer.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("PostCodesDb")));
builder.Services.AddScoped<IDataRepository, PostDataRepository>();
builder.Services.AddScoped<IRepository<AddressInfo>, AUPRepository>();
builder.Services.AddScoped<IRepository<DistModel>, DistRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Menu}/{action=Index}/{id?}");

app.Run();
