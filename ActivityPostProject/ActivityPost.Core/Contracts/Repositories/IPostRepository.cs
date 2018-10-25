using ActivityPost.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ActivityPost.Core.Contracts.Repositories
{
    public interface IPostRepository : IRepositoryBase<Post>
    {
        IQueryable<Post> GetPosts(string search);
        Post GetById(Guid id);
    }
}
