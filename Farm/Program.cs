using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Farm.Data;
using Farm.Repositories;
using Farm.Interfaces;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<FarmContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("FarmContext") ?? throw new InvalidOperationException("Connection string 'FarmContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IRainRepository,RainRepository>();
builder.Services.AddTransient<ICattleRepository,CattleRepository>();

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
