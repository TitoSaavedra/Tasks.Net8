using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Model.DBContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AplicationDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddAuthentication();
builder
    .Services.AddIdentity<IdentityUser, IdentityRole>(opciones =>
    {
        opciones.SignIn.RequireConfirmedEmail = false;
    })
    .AddEntityFrameworkStores<AplicationDBContext>()
    .AddDefaultTokenProviders();

builder.Services.PostConfigure<CookieAuthenticationOptions>(
    IdentityConstants.ApplicationScheme,
    options =>
    {
        options.LoginPath = "/Users/Login";
        options.AccessDeniedPath = "/Users/AccessDenied";
    }
);

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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
