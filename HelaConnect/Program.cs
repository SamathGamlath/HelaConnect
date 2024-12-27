using HelaConnect.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Database Configurations
//string dbConnectionString = builder.Configuration.GetConnectionString("Default");
//builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(dbConnectionString));

string dbConnectionString = builder.Configuration.GetConnectionString("Connection1");
builder.Services.AddDbContext<AppDbContext>(options => options.UseMySql(dbConnectionString, ServerVersion.AutoDetect(dbConnectionString)));
//options.UseMySql(dbConnectionString, ServerVersion.AutoDetect(dbConnectionString)));

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
