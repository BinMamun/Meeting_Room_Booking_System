using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using MeetingRoomBookingSystem.Infrastructure;
using MeetingRoomBookingSystem.Infrastructure.Extensions;
using MeetingRoomBookingSystem.Web;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Microsoft.AspNetCore.Identity;
using MeetingRoomBookingSystem.Infrastructure.Identity;

#region Configure Bootstrap Logger using serilog 
var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(config)
                .CreateBootstrapLogger();
#endregion

try
{
    Log.Information("Application Starting up...");

    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");


    var migrationAssembly = Assembly.GetExecutingAssembly().FullName;

    #region Serilog integration for Application logs

    builder.Host.UseSerilog((services, ls) => ls
                .Enrich.FromLogContext()
                .ReadFrom.Configuration(builder.Configuration));

    #endregion

    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(connectionString, (x) => x.MigrationsAssembly(migrationAssembly)));

    #region Autofac Configuration For Dependency Injection

    builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory(
        containerBuilder =>
        {
            containerBuilder.RegisterModule(new WebModule(connectionString, migrationAssembly));
        }));

    #endregion

    builder.Services.AddDatabaseDeveloperPageExceptionFilter();

    builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ApplicationDbContext>();

    //builder.Services.AddIdentity();

    builder.Services.AddControllersWithViews();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseMigrationsEndPoint();
    }
    else
    {
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

    app.UseHttpsRedirection();
    app.UseRouting();

    app.UseAuthorization();

    app.MapStaticAssets();

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}")
        .WithStaticAssets();

    app.MapRazorPages()
       .WithStaticAssets();

    Log.Information("Application Started Sucessfully");
    app.Run();
}

catch (Exception ex)
{
    Log.Fatal(ex, "Fatal Error occurred while starting the application");
}
finally
{
    Log.CloseAndFlush();
}




