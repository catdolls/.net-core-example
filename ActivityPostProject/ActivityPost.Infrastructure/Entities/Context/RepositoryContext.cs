using ActivityPost.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ActivityPost.Infrastructure.Entities.Context
{
    public class RepositoryContext: DbContext
    {
        public RepositoryContext(DbContextOptions options)
           : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }
    }
}
