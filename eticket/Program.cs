using Eticket.Data;
using Eticket.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
/*var _con = builder.Configuration.GetConnectionString("mydb");
builder.Services.AddDbContext<DbContext>(p => p.UseSqlServer(_con));*/
builder.Services.AddDbContext<AppDbContext>(Con => Con.UseSqlServer(builder.Configuration.GetConnectionString("mydb")));
builder.Services.AddScoped<IActorServices ,ActorServices > ();
builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(10);
    options.Cookie.Name = "Eticket_Cookie";
    options.Cookie.HttpOnly = false;
    options.Cookie.Path = "/";
    options.Cookie.SecurePolicy = CookieSecurePolicy.None;
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.LoginPath = "/accounts/login";
    options.ExpireTimeSpan = TimeSpan.FromMinutes(10);
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
app.UseAuthentication();//middle ware
app.UseAuthorization();
app.UseSession();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
eTickets.Data.ApplicationDbInitialiser.Seed(app);

app.Run();
