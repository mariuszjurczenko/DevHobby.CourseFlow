using DevHobby.CourseFlow.Application.Contracts.Persistence;
using DevHobby.CourseFlow.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DevHobby.CourseFlow.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(
                            this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DevHobbyDbContext>(options =>
           options.UseSqlite(configuration.GetConnectionString("DevHobbyCourseFlowConnectionString")));

        services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<ICourseRepository, CourseRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();

        return services;
    }
}
