using ActivityPost.Core.Contracts.Repositories;
using ActivityPost.Core.Models;
using ActivityPost.Infrastructure.Entities.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ActivityPost.Infrastructure.Entities.Repositories
{
    public class PostRepository : RepositoryBase<Post>, IPostRepository
    {
        public PostRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IQueryable<Post> GetPosts(string search)
        {
            return FindByCondition(x => x.Title.Contains(search))
                .OrderByDescending(x => x.CreatedDate)
                .AsQueryable();
        }

        public Post GetById(Guid id)
        {
            return FindByCondition(x => x.Id == id).FirstOrDefault();
        }
    }
}
