using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NSE.WebApp.MVC.Configuration;

namespace NSE.WebApp.MVC;

public class Startup
{
    public Startup(IHostEnvironment hostingEnvironment)
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(hostingEnvironment.ContentRootPath)
            .AddJsonFile("appsettings.json", true, true)
            .AddJsonFile($"appsettings.{hostingEnvironment.EnvironmentName}.json", true, true)
            .AddEnvironmentVariables();

        if (hostingEnvironment.IsDevelopment()) builder.AddUserSecrets<Startup>();

        Configuration = builder.Build();
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddIdentityConfiguration();

        services.AddMvcConfiguration(Configuration);

        services.RegisterServices(Configuration);
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseMvcConfiguration(env);
    }
}