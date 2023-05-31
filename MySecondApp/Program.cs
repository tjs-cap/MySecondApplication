using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MySecondApp.Areas.Identity.Data;
using MySecondApp.Data;
using Microsoft.Extensions.DependencyInjection;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MoviesDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MoviesDBContext") ?? throw new InvalidOperationException("Connection string 'MoviesDBContext' not found.")));
var connectionString = builder.Configuration.GetConnectionString("UserDBContextConnection") ?? throw new InvalidOperationException("Connection string 'UserDBContextConnection' not found.");

builder.Services.AddDbContext<UserDBContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<UserDBContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();
// builder.Services.AddRazorPages();

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
app.MapRazorPages();
app.Run();
