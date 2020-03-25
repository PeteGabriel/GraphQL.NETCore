using System.Collections.Generic;
using System.Threading.Tasks;
using GraphApiNetCore.Repository.entities;
using Microsoft.EntityFrameworkCore;

namespace GraphApiNetCore.Repository
{
    public class ProductRepository: IRepository
    {
        private readonly CarvedRockDbContext _carvedRockDbContext;

        public ProductRepository(CarvedRockDbContext dbContext)
        {
            this._carvedRockDbContext = dbContext;
        }

        public Task<List<Product>> GetProducts()
        {
            return _carvedRockDbContext.Products.ToListAsync();
        }

        public void Dispose()
        {
            _carvedRockDbContext?.Dispose();
        }
    }
}