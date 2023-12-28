using Dal.SashaProject;
using Dal.SashaProject.Interfaces;
using Dal.SashaProject.Repository;
using Domain.SashaProject.Entity;
using Domain.SashaProject.ViewModels;
using Microsoft.EntityFrameworkCore;
using SashaProject;
using Service.SashaProject.Implementations;
using Service.SashaProject.IService;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<TaxtaxContext>(options =>
options.UseNpgsql(connection));


builder.Services.AddScoped<IAutoRepository, AutoRepository > ();
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IDriverRepository, DriverRepository>();
builder.Services.AddScoped<IManagerRepository, ManagerRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

builder.Services.AddScoped<IAutoService, AutoService>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IDriverService, DriverService>();
builder.Services.AddScoped<IManagerService, ManagerService>();
builder.Services.AddScoped<IOrderService, OrderService>();

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

