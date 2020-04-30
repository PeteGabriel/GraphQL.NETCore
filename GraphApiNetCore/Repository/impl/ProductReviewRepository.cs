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
        
        public async Task<ILookup<int, ProductReview>> FetchByProducts(IEnumerable<int> prodIds)
        {
            var tmp = await _context.Reviews.Where(r => prodIds.Contains(r.ProductId)).ToListAsync();
            return tmp.ToLookup(r => r.ProductId);
        }

        public Task<ProductReview> GetById(int id)
        {
            return _context.Reviews.Where((review) => review.Id.Equals(id)).FirstOrDefaultAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}