using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphApiNetCore.Repository.entities;
using Microsoft.EntityFrameworkCore;

namespace GraphApiNetCore.Repository.impl
{
    public class ProductRepository: IRepository<Product>
    {
        private readonly CarvedRockDbContext _context;

        public ProductRepository(CarvedRockDbContext dbContext) => _context = dbContext;


        public Task<List<Product>> All() => _context.Products.ToListAsync();

        public Task<Product> GetById(int id)
        {
            return _context.Products.Where((product) => product.Id.Equals(id)).FirstOrDefaultAsync();
        }

        public async Task<Product> Add(Product p)
        {
            var nT = await _context.Products.AddAsync(p);
            await _context.SaveChangesAsync();
            return nT.Entity;
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}