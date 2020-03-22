using System.Collections.Generic;
using System.Threading.Tasks;
using GraphApiNetCore.Repository.entities;
using Microsoft.EntityFrameworkCore;

namespace GraphApiNetCore.Repository
{
    public class ProductRepository
    {
        public CarvedRockDbContext _CarvedRockDbContext;

        public ProductRepository(CarvedRockDbContext dbContext)
        {
            this._CarvedRockDbContext = dbContext;
        }

        public Task<List<Product>> GetProducts()
        {
            return _CarvedRockDbContext.Products.ToListAsync();
        }
    }
}