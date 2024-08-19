using IRWalks.API.Data;
using IRWalks.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace IRWalks.API.Repositories;

public class SQLRegionRepository : IRegionRepository
{
    private readonly IRWalksDbContext _dbContext;

    public SQLRegionRepository(IRWalksDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<Region> AddAsync(Region region)
    {
        await  _dbContext.Regions.AddAsync(region);
        await _dbContext.SaveChangesAsync();
        return region;
    }

    public async Task<Region?> DeleteAsync(Guid id)
    {
        var existingRegion = await _dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
        if(existingRegion == null)
        {
            return null;
        }
         _dbContext.Regions.Remove(existingRegion);
        await _dbContext.SaveChangesAsync();
        return existingRegion;
    }

    public async Task<IEnumerable<Region>> GetAllAsync()
    {
        return await _dbContext.Regions.ToListAsync();
    }

    public async Task<Region?> GetAsync(Guid id)
    {
        return await _dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Region?> UpdateAsync(Guid id, Region region)
    {
        var existingRegion = await _dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
        if (existingRegion == null)
        {
            return null;
        }
        existingRegion.Code = region.Code;
        existingRegion.Name = region.Name;
        existingRegion.RegionImageUrl = region.RegionImageUrl;
        
        await _dbContext.SaveChangesAsync();
        return existingRegion;
    }
}
