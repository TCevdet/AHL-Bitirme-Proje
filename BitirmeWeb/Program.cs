
using Bitirme.DataAccess.Data;
using Bitirme.DataAccess.Repository;
using Bitirme.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Bitirme.Utility;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//kullan�c�lara identity tan�mlamak i�in AddIdentity<IdentityUser,IdentityRole>() ile DefaultIdentity'yi de�i�tirdim
builder.Services.AddIdentity<IdentityUser,IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = $"/Identity/Account/Login";
    options.LogoutPath = $"/Identity/Account/Logout";
    options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
});
//identity sayfalar� razor pages oldu�u i�in builder'� mvc projemize kendimiz eklemeliyiz:
builder.Services.AddRazorPages();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IEmailSender, EmailSender>();

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
//identity ekledikten sonra �nce Authorization ekledim
app.UseAuthentication();
app.UseAuthorization();
//abuilder'� ekledikten sonra razor pages i�in map'liyoruz
app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{area=Users}/{controller=Home}/{action=Index}/{id?}");

app.Run();
