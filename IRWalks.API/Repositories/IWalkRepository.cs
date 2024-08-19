using IRWalks.API.Models.Domain;

namespace IRWalks.API.Repositories;

public interface IWalkRepository
{
    Task<IEnumerable<Walk>> GetAllAsync();

    Task<Walk?> GetAsync(Guid id);

    Task<Walk> AddAsync(Walk Walk);

    Task<Walk?> DeleteAsync(Guid id);

    Task<Walk?> UpdateAsync(Guid id, Walk Walk);
}
