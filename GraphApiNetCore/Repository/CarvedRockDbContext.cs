using GraphApiNetCore.Repository.entities;
using Microsoft.EntityFrameworkCore;

namespace GraphApiNetCore.Repository
{
    public class CarvedRockDbContext : DbContext
    {
        public CarvedRockDbContext(DbContextOptions<CarvedRockDbContext> options): base(options)
        {
            
        }
        
        public DbSet<Product> Products { get; set; }
    }
}