using Microsoft.EntityFrameworkCore;
using SpoteFinder.Application.Services;
using SpoteFinder.Domain.Interfaces;
using SpoteFinder.Persistence;
using SpoteFinder.Persistence.Repository;
using SpoteFinder.Web.Hubs;
using SpoteFinder.Web.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add services to the container
builder.Services.AddControllersWithViews();
builder.Services.AddSignalR();
builder.Services.AddRazorPages();

// Add DbContext and configure database connection
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Dependency injection for repositories and services
builder.Services.AddScoped<IParkingSpotRepository, ParkingSpotRepository>();
builder.Services.AddScoped<IReservationRepository, ReservationRepository>();
builder.Services.AddScoped<ParkingSpotService>();
builder.Services.AddScoped<ReservationService>();
builder.Services.AddScoped<INotificationService, SignalRNotificationService>();



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

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

// Map routes and SignalR hubs
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=ParkingSpot}/{action=Index}/{id?}");

app.MapHub<ParkingSpotHub>("/parkingSpotHub");


app.Run();
