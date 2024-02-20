using Microsoft.EntityFrameworkCore;
using SelfRepositoryAsp.Models;

namespace SelfRepositoryAsp.DatabaseContext;

public class EmployeeDbContext(DbContextOptions<EmployeeDbContext> dbContext) : DbContext(dbContext)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EmployeeDbContext).Assembly);
    }

public DbSet<SelfRepositoryAsp.Models.Employee> Employee { get; set; } = default!;
}
