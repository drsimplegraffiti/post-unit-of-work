using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PosterunitOfwork.Core.IRepositories.IConfiguration
{
    public interface IUnitOfWork
    {
        IPostRepository Posts { get; }

        Task CompleteAsync();
    }
}