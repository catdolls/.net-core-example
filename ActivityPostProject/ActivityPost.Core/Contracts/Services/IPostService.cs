using ActivityPost.Core.DTOs;
using ActivityPost.Services.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ActivityPost.Core.Contracts.Services
{
    public interface IPostService
    {
        PostListDTO GetAll(PagingParams pagingParams);
        PostDTO GetById(Guid id);
        void Create(PostDTO postDTO);
        void Update(PostDTO postDTO);
        void Delete(Guid id);
    }
}
