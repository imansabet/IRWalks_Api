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

    public async Task<IEnumerable<Walk>> GetAllAsync()
    {
        return await _dbContext.Walks.Include("Region").Include("Difficulty").ToListAsync();
    }

    public async Task<Walk?> GetAsync(Guid id)
    {
        return await _dbContext.Walks.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Walk?> UpdateAsync(Guid id, Walk Walk)
    {
        var existingWalk = await _dbContext.Walks.FirstOrDefaultAsync(x => x.Id == id);
        if (existingWalk == null)
        {
            return null;
        }
        existingWalk.Code = Walk.Code;
        existingWalk.Name = Walk.Name;
        existingWalk.WalkImageUrl = Walk.WalkImageUrl;
        
        await _dbContext.SaveChangesAsync();
        return existingWalk;
    }
}
