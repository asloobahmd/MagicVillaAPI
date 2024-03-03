using MagicVillaAPI_API.Models;
using Microsoft.EntityFrameworkCore;

namespace MagicVillaAPI_API.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }

        public DbSet<Villa> Villas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Villa>().HasData(
                new Villa
                {
                    Id = 1,
                    Name = "Royal Villa",
                    Details = "Sample details",
                    ImageUrl = "https://cf.bstatic.com/xdata/images/hotel/max1024x768/521880995.jpg?k=1c30caf791925fbd5f47ceee91c6cf24e073f6dbab9c14cbd83f9cc81c31735f&o=&hp=1",
                    Occupancy = 4,
                    Rate = 200,
                    Sqft = 550,
                    Amenity = "",
                    CreatedDate = DateTime.Now
                },
                 new Villa
                 {
                     Id = 2,
                     Name = "Bliss Villa",
                     Details = "Sample details",
                     ImageUrl = "https://cf.bstatic.com/xdata/images/hotel/max1024x768/521881899.jpg?k=58328b33c718de90b57afc53016df5c9f8cfdd32cc92736a8fa4e8f493e70d84&o=&hp=1",
                     Occupancy = 5,
                     Rate = 180,
                     Sqft = 500,
                     Amenity = "",
                     CreatedDate = DateTime.Now
                 }
                );
        }
    }
}
