using IRWalks.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace IRWalks.API.Data;

public class IRWalksDbContext : DbContext
{
    public IRWalksDbContext(DbContextOptions<IRWalksDbContext> options) : base(options)
    {
        
    }
    public DbSet<Region> Regions { get; set; }
    public DbSet<Walk> Walks { get; set; }
    public DbSet<Difficulty> Difficulty { get; set; }
}
