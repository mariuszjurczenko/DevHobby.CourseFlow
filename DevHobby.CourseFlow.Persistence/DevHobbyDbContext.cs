using DevHobby.CourseFlow.Domain.Common;
using DevHobby.CourseFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevHobby.CourseFlow.Persistence;

public class DevHobbyDbContext : DbContext
{
    public DevHobbyDbContext(DbContextOptions<DevHobbyDbContext> options) : base(options)
    {       
    }

    public DbSet<Course> Courses { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Order> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DevHobbyDbContext).Assembly);
        SeedInitialData(modelBuilder);
    }

    private void SeedInitialData(ModelBuilder modelBuilder)
    {
        throw new NotImplementedException();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedDate = DateTime.UtcNow;
                    break;
                case EntityState.Modified:
                    entry.Entity.LastModifiedDate = DateTime.UtcNow;
                    break;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}
