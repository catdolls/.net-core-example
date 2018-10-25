using ActivityPost.Services.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ActivityPost.Core.DTOs
{
    public class PostListDTO
    {
        public PagingHeader Paging { get; set; }
        public List<PostDTO> Items { get; set; }
    }
}
