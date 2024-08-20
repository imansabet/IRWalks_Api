using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IRWalks.API.Data
{
    public class IRWalksAuthDbContext : IdentityDbContext
    {
        public IRWalksAuthDbContext(DbContextOptions<IRWalksAuthDbContext> options) : base(options)
        {
                
        }
    }
}
