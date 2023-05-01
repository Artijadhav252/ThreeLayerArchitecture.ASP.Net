using Microsoft.EntityFrameworkCore;
using ThreeLayerArchitecture.ASP.Net.BAL;
using ThreeLayerArchitecture.ASP.Net.DAL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<MvcfirstContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultCS")));
builder.Services.AddScoped<IUserRePository, UserRePositorySQLDB>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=User}/{action=Index}/{id?}");

app.Run();
