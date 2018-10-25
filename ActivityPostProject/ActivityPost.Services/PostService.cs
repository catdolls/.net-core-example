using ActivityPost.Core.Contracts.Repositories;
using ActivityPost.Core.Contracts.Services;
using ActivityPost.Core.DTOs;
using ActivityPost.Core.Extensions;
using ActivityPost.Core.Models;
using ActivityPost.Services.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ActivityPost.Services
{
    public class PostService : IPostService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public PostService(IRepositoryWrapper repositoryWrapper)
        {
            this._repositoryWrapper = repositoryWrapper;
        }

        public void Create(PostDTO postDTO)
        {
            Post post = new Post();
            this.UpdatePostModel(post, postDTO);
            post.CreatedDate = DateTime.UtcNow.ToUnixTimeStamp();

            this._repositoryWrapper.Post.Create(post);
            this._repositoryWrapper.Post.Save();
        }

        public void Delete(Guid id)
        {
            Post post = this._repositoryWrapper.Post.GetById(id);

            if (post != null)
            {
                this._repositoryWrapper.Post.Delete(post);
                this._repositoryWrapper.Post.Save();
            }
        }

        public PostListDTO GetAll(PagingParams pagingParams)
        {
            IQueryable<PostDTO> query = this._repositoryWrapper.Post.GetPosts(pagingParams.Search).Select(x => new PostDTO(x));

            PagedList<PostDTO> postPagedList = new PagedList<PostDTO>(query, pagingParams.PageNumber, pagingParams.PageSize);

            return new PostListDTO()
            {
                Paging = postPagedList.GetHeader(),
                Items = postPagedList.List.ToList()
            };
        }

        public PostDTO GetById(Guid id)
        {
            PostDTO postDTO = new PostDTO(this._repositoryWrapper.Post.GetById(id));
            return postDTO;
        }

        public void Update(PostDTO postDTO)
        {
            Post post = this._repositoryWrapper.Post.GetById(postDTO.Id);

            if(post != null)
            {
                this.UpdatePostModel(post, postDTO);
                this._repositoryWrapper.Post.Update(post);
                this._repositoryWrapper.Post.Save();
            }
        }

        private void UpdatePostModel(Post post, PostDTO postDTO)
        {
            post.Title = postDTO.Title;
            post.Description = postDTO.Description;
            post.Author = postDTO.Author;
            post.UpdatedDate = DateTime.UtcNow.ToUnixTimeStamp();
        }
    }
}
