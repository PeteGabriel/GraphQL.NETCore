using System.Collections.Generic;
using System.Threading.Tasks;
using GraphApiNetCore.Repository.entities;

namespace GraphApiNetCore.Repository
{
    public interface IRepository
    {
        Task<List<Product>> GetProducts();
    }
}