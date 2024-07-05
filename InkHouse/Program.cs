
using InkHouse.Data;
using InkHouse.Repositories;
using InkHouse.Repositories.Base;
using InkHouse.Services;
using InkHouse.Services.Base;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<InkHouseDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("MsSqlServer");
    options.UseSqlServer(connectionString);
});


builder.Services.AddTransient<IPaintingService, PaintingService>();
//builder.Services.AddTransient<IPaintingRepository, PaintingEfRepository>();
builder.Services.AddTransient<IPaintingRepository, PaintingDapperRepository>();



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
