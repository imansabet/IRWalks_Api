using IRWalks.API.Models.Domain;
using Microsoft.AspNetCore.Mvc;

namespace IRWalks.API.Repositories;

public interface IWalkRepository
{
    Task<IEnumerable<Walk>> GetAllAsync(string? filterOn = null,string? filterQuery = null , string? sortBy = null, bool IsAscending = true);

    Task<Walk?> GetAsync(Guid id);

    Task<Walk> AddAsync(Walk Walk);

    Task<Walk?> DeleteAsync(Guid id);

    Task<Walk?> UpdateAsync(Guid id, Walk Walk);
}
