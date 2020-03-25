using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GraphApiNetCore.Repository.entities;

namespace GraphApiNetCore.Repository
{
    public interface IRepository: IDisposable
    {
        Task<List<Product>> GetProducts();
    }
}