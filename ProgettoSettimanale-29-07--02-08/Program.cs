using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ProgettoSettimanale_29_07__02_08.BusinessLayer;
using ProgettoSettimanale_29_07__02_08.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services
    .AddScoped<IProductService, ProductService>()
    .AddScoped<ICartService, CartService>()
    .AddScoped<IOrderService, OrderService>()
;

var conn = builder.Configuration.GetConnectionString("SqlServer");
builder.Services.AddDbContext<DataContext>(opt => opt.UseSqlServer(conn));

builder.Services
    .AddAuthentication(opt => {
        opt.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        opt.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        opt.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    })
    .AddCookie(opt => {
        opt.LoginPath = "/Account/Login";
        opt.AccessDeniedPath = "/Account/AccessDenied";
    })
    ;

builder.Services.AddAuthorization(opt =>
    {
        opt.AddPolicy(ProgettoSettimanale_29_07__02_08.Policies.isLoggedAdmin, cfg => cfg.RequireRole("Admin"));
        opt.AddPolicy(ProgettoSettimanale_29_07__02_08.Policies.baseUser, cfg => cfg.RequireRole("User"));
        opt.AddPolicy(ProgettoSettimanale_29_07__02_08.Policies.isLogged, cfg => cfg.RequireAuthenticatedUser());
    });

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
