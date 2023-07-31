using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PosterunitOfwork.Core.IRepositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task<T> Add(T entity); // T is the type of entity 
        Task<T> Update(T entity); // You can also use bool instead of T or void
        Task<T> Delete(int id);
    }
}