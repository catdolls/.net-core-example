using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ActivityPost.Core.Contracts.Repositories;
using ActivityPost.Core.Contracts.Services;
using ActivityPost.Core.DTOs;
using ActivityPost.Core.Models;
using ActivityPost.Services.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ActivityPost.Api.Controllers
{
    [Route("api/ActivityPost")]
    public class ActivityPostController : Controller
    {
        private IPostService _postService;

        public ActivityPostController(IPostService postService)
        {
            _postService = postService;
        }

        // GET: api/ActivityPost
        [HttpGet]
        [ProducesResponseType(typeof(PostListDTO), 200)]
        [ProducesResponseType(typeof(void), 400)]
        [ProducesResponseType(typeof(void), 404)]
        public IActionResult Get([FromQuery] PagingParams pagingParams)
        {
            if(pagingParams != null)
            {
                PostListDTO postList = this._postService.GetAll(pagingParams);
                Response.Headers.Add("X-Pagination", postList.Paging.ToJson());
                return Ok(postList);
            }
            else
                return StatusCode(400);
        }

        // GET: api/ActivityPost/5
        [HttpGet("{id}", Name = "Get")]
        [ProducesResponseType(typeof(PostDTO), 200)]
        [ProducesResponseType(typeof(void), 400)]
        [ProducesResponseType(typeof(void), 404)]
        public IActionResult Get(Guid id)
        {
            PostDTO post = this._postService.GetById(id);

            if (post != null)
                return Ok(post);
            else
                return NotFound();
        }
        
        // POST: api/ActivityPost
        [HttpPost]
        public IActionResult Post([FromBody]PostDTO postDTO)
        {
            if (postDTO == null)
                return BadRequest("Post object is null");
            if (!ModelState.IsValid)
                return BadRequest("Invalid model object");

            this._postService.Create(postDTO);

            return Created(string.Empty, null);
        }
        
        // PUT: api/ActivityPost/5
        [HttpPut]
        public IActionResult Put([FromBody]PostDTO postDTO)
        {
            if (postDTO == null)
                return BadRequest("Post object is null");
            if (!ModelState.IsValid)
                return BadRequest("Invalid model object");

            this._postService.Update(postDTO);

            return NoContent();
           
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            this._postService.Delete(id);
            return NoContent();
        }
    }
}
