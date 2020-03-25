using System.Reflection;
using GraphApiNetCore.Repository.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace GraphApiNetCore.Repository
{
    public class CarvedRockDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        private readonly IConfiguration _configuration;
     
        public CarvedRockDbContext(DbContextOptions<CarvedRockDbContext> options, IConfiguration config): base(options)
        {
            this._configuration = config;
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(this._configuration["ConnectionStrings:CarvedRock"], 
                options =>
            {
                options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
            });
            base.OnConfiguring(optionsBuilder);
        }
        
    }
}