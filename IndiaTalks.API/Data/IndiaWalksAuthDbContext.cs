using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IndiaTalks.API.Data
{
    public class IndiaWalksAuthDbContext : IdentityDbContext
    {
        public IndiaWalksAuthDbContext(DbContextOptions<IndiaWalksAuthDbContext> options): base(options) 
       
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //create guid and convert into string

            var readerRoleId = "3ad126fb-254d-4bc3-a5e4-f4bb4a33d12b";
            var writerRoleId = "d01bfcca-32ca-4be5-a69e-c9d79f412380";

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
                }
            };

            builder.Entity<IdentityRole>().HasData(roles);
        }

    }
}
