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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        var difficulties = new List<Difficulty>()
        {
            new Difficulty()
            {
                Id = Guid.Parse("98a39a48-78fa-41d7-ad97-445ccb84177c") ,
                Name = "Easy",
            },
            new Difficulty()
            {
                Id = Guid.Parse("d817f8e9-5b09-4181-b064-8069b4b8fa61") ,
                Name = "Medium",
            },
            new Difficulty()
            {
                Id = Guid.Parse("95ad1fcd-7876-4b09-be77-859c9e94a9b3") ,
                Name = "Hard",
            }
        };
        modelBuilder.Entity<Difficulty>().HasData(difficulties);

        var regions = new List<Region>
        {
            new Region
            {
                Id = Guid.Parse("75a93ca7-7b5c-4038-b0c0-140952f70e4f"),
                Name = "Fars",
                Code = "FRS",
                RegionImageUrl = "region.jpg",

            },
            new Region
            {
                Id = Guid.Parse("0a2c8388-f3cc-4328-9b3e-6f47b92c4a11"),
                Name = "Tabriz",
                Code = "TBZ",
                RegionImageUrl = "region.jpg",

            },
            new Region
            {
                Id = Guid.Parse("10191792-8707-4768-9e95-7aa628328853"),
                Name = "Tehran",
                Code = "TEH",
                RegionImageUrl = "region.jpg",

            },
            new Region
            {
                Id = Guid.Parse("5d860541-eb55-4aa7-9fd5-1c525f617788"),
                Name = "Semnan",
                Code = "SEM",
                RegionImageUrl = "region.jpg",

            },
        };
        modelBuilder.Entity<Region>().HasData(regions);

    }
}
