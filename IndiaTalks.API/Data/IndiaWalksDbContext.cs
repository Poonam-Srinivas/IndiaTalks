using IndiaTalks.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace IndiaTalks.API.Data
{
    public class IndiaWalkAuthDbContext : DbContext
    {
        //create contructor
        public IndiaWalkAuthDbContext(DbContextOptions<IndiaWalkAuthDbContext> dbContextOptions) :base(dbContextOptions)
        {
                
        }

        //Represents collections in the database
        //created dbset inside dbcontext class
        public DbSet<Difficulty> Difficulties { get; set; } 
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // seed the data for difficulties
            //easy hard medium

            var difficulties = new List<Difficulty>()
            {
                new Difficulty()
                {
                    Id= Guid.Parse("c9ce4488-719e-45d3-999f-9983ea91f5ad"),
                    Name="Easy"

                },
                new Difficulty()
                {
                    Id=Guid.Parse("114b845c-7c38-4d10-8d83-c5131acf9bbf"),
                    Name="Medium"

                },
                new Difficulty()
                {
                    Id=Guid.Parse("abf1d274-0bd5-4d07-93b9-c87a86ebe557"),
                    Name="Hard"

                },
            };
            //Seed difficulties  to the database
            modelBuilder.Entity<Difficulty>().HasData(difficulties);

            //Seed data for Regions

            var regions = new List<Region>()
            {

                new Region()
                {
                    Id=Guid.Parse("ea75bac5-dbdd-4320-ac7a-644c9c9dd06b"),
                    Name="Auckland",
                    Code="AKL",
                    RegionImageUrl="null"
                },
                new Region()
                {
                    Id=Guid.Parse("f9f2b14a-9ba9-4e51-8521-84fcf8e12511"),
                    Name="Island",
                    Code="ISL",
                    RegionImageUrl="null"
                },
                new Region()
                {
                    Id=Guid.Parse("15fbee49-7914-41cd-9d97-32afff4e8535"),
                    Name="Miniland",
                    Code="MIL",
                    RegionImageUrl="null"
                },
                 new Region()
                {
                    Id=Guid.Parse("d0aa2d4a-65d7-4f3c-8c6f-544c737725a2"),
                    Name="Ireland",
                    Code="IRL",
                    RegionImageUrl="null"
                },
                 new Region
                {
                    Id = Guid.Parse("f7248fc3-2585-4efb-8d1d-1c555f4087f6"),
                    Name = "Auckland",
                    Code = "AKL",
                    RegionImageUrl = "https://images.pexels.com/photos/5169056/pexels-photo-5169056.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                },
                new Region
                {
                    Id = Guid.Parse("6884f7d7-ad1f-4101-8df3-7a6fa7387d81"),
                    Name = "Northland",
                    Code = "NTL",
                    RegionImageUrl = null
                },
                new Region
                {
                    Id = Guid.Parse("14ceba71-4b51-4777-9b17-46602cf66153"),
                    Name = "Bay Of Plenty",
                    Code = "BOP",
                    RegionImageUrl = null
                },
                new Region
                {
                    Id = Guid.Parse("cfa06ed2-bf65-4b65-93ed-c9d286ddb0de"),
                    Name = "Wellington",
                    Code = "WGN",
                    RegionImageUrl = "https://images.pexels.com/photos/4350631/pexels-photo-4350631.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                },
                new Region
                {
                    Id = Guid.Parse("906cb139-415a-4bbb-a174-1a1faf9fb1f6"),
                    Name = "Nelson",
                    Code = "NSN",
                    RegionImageUrl = "https://images.pexels.com/photos/13918194/pexels-photo-13918194.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                },
                new Region
                {
                    Id = Guid.Parse("f077a22e-4248-4bf6-b564-c7cf4e250263"),
                    Name = "Southland",
                    Code = "STL",
                    RegionImageUrl = null
                },
            };

            modelBuilder.Entity<Region>().HasData(regions);
        }
        
    }
}
