using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PosterunitOfwork.Core.IRepositories;
using PosterunitOfwork.Data;

namespace PosterunitOfwork.Core.Repositories
{
    public class GenericRepository<T>:IGenericRepository<T> where T:class
    {
         protected ApplicationDbContext _context;
        protected DbSet<T> dbSet;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            dbSet = _context.Set<T>();
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await dbSet.ToListAsync();
        }

        public virtual async Task<T> GetById(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual async Task<T> Add(T entity)
        {
            dbSet.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<T> Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<T> Delete(int id)
        {
            var entity = await dbSet.FindAsync(id);
            if (entity == null)
            {
                return entity;
            }
            dbSet.Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        
    }
}