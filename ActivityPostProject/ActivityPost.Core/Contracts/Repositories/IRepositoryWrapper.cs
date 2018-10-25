using System;
using System.Collections.Generic;
using System.Text;

namespace ActivityPost.Core.Contracts.Repositories
{
    public interface IRepositoryWrapper
    {
        IPostRepository Post { get; }
    }
}
