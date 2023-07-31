using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PosterunitOfwork.Core.IRepositories;
using PosterunitOfwork.Core.IRepositories.IConfiguration;
using PosterunitOfwork.Core.Repositories;

namespace PosterunitOfwork.Data
{
    public class UnitOfWork:IUnitOfWork, IDisposable

    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Posts = new PostRepository(_context);
        }

        public IPostRepository Posts { get; private set; }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
       
