using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IRWalks.API.Data
{
    public class IRWalksAuthDbContext : IdentityDbContext
    {
        public IRWalksAuthDbContext(DbContextOptions<IRWalksAuthDbContext> options) : base(options)
        {}
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var readerRoleId = "9002ed86-e1e7-4d82-9c07-5505719fec03";

            var writerRoleId = "5cbcd6a1 - fc89 - 4cc6 - 870e-b8578dc4269c"; 


            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = readerRoleId,
                    ConcurrencyStamp = readerRoleId,
                    Name = "Reader",
                    NormalizedName = "Reader".ToUpper()
                },
                new IdentityRole
                {
                    Id = writerRoleId,
                    ConcurrencyStamp = writerRoleId,
                    Name = "Writer",
                    NormalizedName = "Writer".ToUpper()
                },
            };
            builder.Entity<IdentityRole>().HasData(roles);
        }

    }
}
