using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NewHMS.Data;
using NewHMS.Models;
using NewHMS.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Base de données
var connectionString = builder.Configuration.GetConnectionString("AuthDbConnection");
builder.Services.AddDbContext<DatabaseContext>(options =>
options.UseSqlServer(connectionString));


// For Identity  
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<DatabaseContext>()
    .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options => options.LoginPath = "/UserAuthentication/Login");

// Add services to the container.
builder.Services.AddScoped<IUserAuthenticationService, UserAuthenticationService>();

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
    pattern: "{controller=UserAuthentication}/{action=Login}/{id?}");

app.Run();
