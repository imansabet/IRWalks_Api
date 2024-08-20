using IRWalks.API.Data;
using IRWalks.API.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

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

    public async Task<IEnumerable<Walk>> GetAllAsync(string? filterOn = null, string? filterQuery = null
        , string? sortBy = null, bool IsAscending = true ,int pageNumber = 1, int pageSize = 1000)
    {

        var walks = _dbContext.Walks.Include("Region").Include("Difficulty").AsQueryable();

        if(string.IsNullOrWhiteSpace(filterOn) == false && string.IsNullOrWhiteSpace(filterQuery) == false)
        {
            if (filterOn.Equals("Name", StringComparison.OrdinalIgnoreCase))
            {
                walks = walks.Where(x => x.Name.Contains(filterQuery));
            }
        }
        if (string.IsNullOrWhiteSpace(sortBy) == false)
        {
            if (sortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
            {
                walks = IsAscending ?  walks.OrderBy(x => x.Name) : walks.OrderByDescending(x => x.Name) ;
            }
            else if(sortBy.Equals("Length", StringComparison.OrdinalIgnoreCase))
            {
                walks = IsAscending ? walks.OrderBy(x => x.LengthInKm) : walks.OrderByDescending(x => x.LengthInKm);

            }
        }
        var skipResults = (pageNumber - 1) * pageSize;



            return await walks.Skip(skipResults).Take(pageSize).ToListAsync();
        
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
