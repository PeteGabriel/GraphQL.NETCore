using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GraphApiNetCore.Repository.entities;

namespace GraphApiNetCore.Repository
{
    public interface IRepository<T>: IDisposable
    {
        Task<List<T>> All();
        
        Task<T> GetById(int id);

        Task<T> Add(T t);
    }
}