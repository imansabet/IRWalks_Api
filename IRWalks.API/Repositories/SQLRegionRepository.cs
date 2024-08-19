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
    public Task<Region> AddAsync(Region region)
    {
        throw new NotImplementedException();
    }

    public Task<Region> DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Region>> GetAllAsync()
    {
        return await _dbContext.Regions.ToListAsync();
    }

    public Task<Region> GetAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Region> UpdateAsync(Guid id, Region region)
    {
        throw new NotImplementedException();
    }
}
