using DataService.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataService;

public class ApplicationContext(DbContextOptions<ApplicationContext> options) : DbContext(options)
{
    public DbSet<User> User { get; init; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            // Fallback configuration if not configured
            optionsBuilder.UseNpgsql("DefaultConnection");
        }
    }
}