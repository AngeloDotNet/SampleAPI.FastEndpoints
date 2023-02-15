using FastEndpoints;
using FastEndpoints.Swagger;
using Microsoft.EntityFrameworkCore;
using SampleAPI.FastEndpoints.Infrastructure;

namespace SampleAPI.FastEndpoints;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {

        services.AddFastEndpoints();
        services.AddSwaggerDoc();

        services.AddDbContext<DataDbContext>(option =>
        {
            option.UseInMemoryDatabase("People");
        });
    }

    public void Configure(WebApplication app)
    {
        IWebHostEnvironment env = app.Environment;

        app.MapFastEndpoints();
        app.UseSwaggerGen();
    }
}