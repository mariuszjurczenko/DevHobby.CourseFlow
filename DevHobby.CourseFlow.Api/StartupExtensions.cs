using DevHobby.CourseFlow.Application;
using DevHobby.CourseFlow.Infrastructure;
using DevHobby.CourseFlow.Persistence;

namespace DevHobby.CourseFlow.Api;

public static class StartupExtensions
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddApplicationServices();
        builder.Services.AddInfrastructureServices(builder.Configuration);
        builder.Services.AddPersistenceServices(builder.Configuration);

        builder.Services.AddControllers();

        builder.Services.AddCors(
            options => options.AddPolicy(
                "open",
                policy => policy.WithOrigins([builder.Configuration["ApiUrl"] ?? "https://localhost:5000",
                    builder.Configuration["BlazorUrl"] ?? "https://localhost:5010"])
        .AllowAnyMethod()
        .SetIsOriginAllowed(pol => true)
        .AllowAnyHeader()
        .AllowCredentials()));

        return builder.Build();
    }

    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        app.UseCors("open");
        app.UseHttpsRedirection();
        app.MapControllers();
        return app; 
    }
}
