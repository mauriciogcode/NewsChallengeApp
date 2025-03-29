using Microsoft.EntityFrameworkCore;
using NewsApi.Domain.Entities;

namespace NewsApi.Infrastructure.Persistence;

public class NewsDbContext : DbContext
{
    public NewsDbContext(DbContextOptions<NewsDbContext> options) : base(options) { }

    public DbSet<News> News { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<News>().HasQueryFilter(n => !n.IsDeleted);  

        
        modelBuilder.Entity<News>()
            .Property(n => n.Date)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");
    }
}
