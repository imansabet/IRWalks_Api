using Microsoft.AspNetCore.Identity;

namespace IRWalks.API.Repositories;

public interface ITokenRepository
{
    string CreateJWTToken(IdentityUser user, List<string> roles);
}
