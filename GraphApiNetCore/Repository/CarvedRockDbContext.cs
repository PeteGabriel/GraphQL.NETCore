using System;
using GraphApiNetCore.Repository.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace GraphApiNetCore.Repository
{
    public class CarvedRockDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductReview> Reviews { get; set; }

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
            modelBuilder.Entity<ProductReview>().ToTable("Reviews");
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

            modelBuilder.Entity<ProductReview>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.ProductId).IsRequired();
                entity.Property(e => e.Title).IsRequired();
                entity.Property(e => e.Review);
            });
            
            this.SeedProducts(modelBuilder);
            this.SeedReviews(modelBuilder);
            
            base.OnModelCreating(modelBuilder);
        }

        private void SeedReviews(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductReview>().HasData(
                new ProductReview
                {
                    Id = 1,
                    ProductId = 1,
                    Title = "Very good shoes !",
                    Review = "I've loved them !! Would buy again !"
                },
                new ProductReview
                {
                    Id = 2,
                    ProductId = 1,
                    Title = "Fine but not great..",
                    Review = "I like them. They are comfortable and such but not pretty."
                },
                new ProductReview
                {
                    Id = 3,
                    ProductId = 2,
                    Title = "Best kayak EVER !",
                    Review = "I've loved it !! Would buy again !"
                });
        }
        
        private void SeedProducts(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Mountain Walkers",
                    Description = "Use these sturdy shoes to pass any mountain range with ease.",
                    Price = 219.5m,
                    Rating = 4,
                    Type = ProductType.Boots,
                    Stock = 12,
                    PhotoFileName = "shutterstock_66842440.jpg",
                    IntroducedAt = DateTimeOffset.Now.AddMonths(-1)
                },
                new Product
                {
                    Id = 2,
                    Name = "Blue Racer",
                    Description = "Simply the fastest kayak on earth and beyond for 2 persons.",
                    Price = 350m,
                    Rating = 5,
                    Type = ProductType.Kayaks,
                    Stock = 8,
                    PhotoFileName = "shutterstock_441989509.jpg",
                    IntroducedAt = DateTimeOffset.Now.AddMonths(-1)
                },
                new Product
                {
                    Id = 3,
                    Name = "Orange Demon",
                    Description = "One person kayak with hyper boost button.",
                    Price = 450m,
                    Rating = 2,
                    Type = ProductType.Kayaks,
                    Stock = 1,
                    PhotoFileName = "shutterstock_495259978.jpg",
                    IntroducedAt = DateTimeOffset.Now.AddMonths(-1)
                }
            );
        }
    }
}