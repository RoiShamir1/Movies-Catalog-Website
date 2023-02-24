using Microsoft.EntityFrameworkCore;
using NLog;
using NLog.Web;
using System;
using WebApplicationASP.Data;
using WebApplicationASP.Repositories;

var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");

try
{
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    builder.Services.AddControllersWithViews();
    var connectionString = builder.Configuration["ConnectionStrings:DefaultConnection"];
    builder.Services.AddDbContext<MyShopData>(options =>
    options.UseLazyLoadingProxies().UseSqlServer(connectionString));

    builder.Services.AddScoped<IRepository, MyRepository>();

    // NLog: Setup NLog for Dependency injection
    builder.Logging.ClearProviders();
    builder.Host.UseNLog();

    var app = builder.Build();

    using (var scope = app.Services.CreateScope())
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<MyShopData>();
        dbContext?.Database.EnsureDeleted();
        dbContext?.Database.EnsureCreated();
    }

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
        pattern: "{controller=Home}/{action=Index}/{id?}");

    app.Run();

}
catch (Exception e)
{
    // NLog: catch setup errors
    logger.Error(e, "Stopped program because of exception");
    throw;
}
finally
{
    // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
    NLog.LogManager.Shutdown();
}