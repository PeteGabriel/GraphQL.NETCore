using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphApiNetCore.Repository.entities;
using Microsoft.EntityFrameworkCore;

namespace GraphApiNetCore.Repository.impl
{
    public class ProductReviewRepository : IRepository<ProductReview>
    {
        private readonly CarvedRockDbContext _context;

        public ProductReviewRepository(CarvedRockDbContext ctx) => _context = ctx;
        
        public Task<List<ProductReview>> All() => _context.Reviews.ToListAsync();

        public Task<List<ProductReview>> FilterByProduct(int prodId) =>
            _context.Reviews.Where(r => r.ProductId.Equals(prodId)).ToListAsync();

        public void Dispose()
        {
            _context?.Dispose();
        }

    }
}