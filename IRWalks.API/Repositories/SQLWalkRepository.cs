using IRWalks.API.Data;
using IRWalks.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace IRWalks.API.Repositories;

public class SQLWalkRepository : IWalkRepository
{
    private readonly IRWalksDbContext _dbContext;

    public SQLWalkRepository(IRWalksDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<Walk> AddAsync(Walk Walk)
    {
        await  _dbContext.Walks.AddAsync(Walk);
        await _dbContext.SaveChangesAsync();
        return Walk;
    }

    public async Task<Walk?> DeleteAsync(Guid id)
    {
        var existingWalk = await _dbContext.Walks.FirstOrDefaultAsync(x => x.Id == id);
        if(existingWalk == null)
        {
            return null;
        }
         _dbContext.Walks.Remove(existingWalk);
        await _dbContext.SaveChangesAsync();
        return existingWalk;
    }

    public async Task<IEnumerable<Walk>> GetAllAsync(string? filterOn = null, string? filterQuery = null)
    {

        var walks = _dbContext.Walks.Include("Region").Include("Difficulty").AsQueryable();

        if(string.IsNullOrWhiteSpace(filterOn) == false && string.IsNullOrWhiteSpace(filterQuery) == false)
        {
            if (filterOn.Equals("Name", StringComparison.OrdinalIgnoreCase))
            {
                walks = walks.Where(x => x.Name.Contains(filterQuery));
            }
        }


        return await walks.ToListAsync();
        
    //return await _dbContext.Walks.Include("Region").Include("Difficulty").ToListAsync();
    }



    public async Task<Walk?> GetAsync(Guid id)
    {
        return await _dbContext.Walks.Include("Region").Include("Difficulty").FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Walk?> UpdateAsync(Guid id, Walk Walk)
    {
        var existingWalk = await _dbContext.Walks.FirstOrDefaultAsync(x => x.Id == id);
        if (existingWalk == null)
        {
            return null;
        }
        existingWalk.RegionId = Walk.RegionId;
        existingWalk.DifficultyId = Walk.DifficultyId;
        existingWalk.LengthInKm = Walk.LengthInKm;
        existingWalk.WalkImageUrl = Walk.WalkImageUrl;
        existingWalk.Description = Walk.Description;
        existingWalk.Name = Walk.Name;
        existingWalk.WalkImageUrl = Walk.WalkImageUrl;
        
        await _dbContext.SaveChangesAsync();
        return existingWalk;
    }
}
