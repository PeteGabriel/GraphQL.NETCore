using System;
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
            optionsBuilder.UseSqlite(this._configuration["ConnectionStrings:CarvedRock"]);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Products");
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name);
                entity.Property(e => e.Description);
                entity.Property(e => e.Price);
                entity.Property(e => e.Rating);
                entity.Property(e => e.Stock);
                entity.Property(e => e.Type);
                entity.Property(e => e.IntroducedAt);
                entity.Property(e => e.PhotoFileName);
            });
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id= 1,
                    Name = "Mountain Walkers",
                    Description = "Use these sturdy shoes to pass any mountain range with ease.",
                    Price = 219.5m,
                    Rating = 4,
                    Type = ProductType.Boots,
                    Stock = 12,
                    PhotoFileName = "shutterstock_66842440.jpg",
                    IntroducedAt = DateTimeOffset.Now.AddMonths(-1)
                }
            );
            
            base.OnModelCreating(modelBuilder);
        }
    }
}