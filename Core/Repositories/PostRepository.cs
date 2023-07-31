using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PosterunitOfwork.Core.IRepositories;
using PosterunitOfwork.Data;
using PosterunitOfwork.Models;

namespace PosterunitOfwork.Core.Repositories
{
    public class PostRepository:GenericRepository<Post>, IPostRepository
    {
        
        public PostRepository(ApplicationDbContext context) : base(context)
        {
        }

         public override async Task<IEnumerable<Post>> GetAll()
        {
            return await _context.Posts.ToListAsync();
        }

        public override async Task<Post> GetById(int id)
        {
            return await _context.Posts.SingleOrDefaultAsync(p => p.Id == id);
        }

        public override async Task<Post> Add(Post entity)
        {
            await _context.Posts.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public override async Task<Post> Update(Post entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }

        public override async Task<Post> Delete(int id)
        {
            var entity = await _context.Posts.FindAsync(id);
            if (entity == null)
            {
                return entity;
            }
            _context.Posts.Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

       


        
    }
}