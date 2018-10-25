using ActivityPost.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ActivityPost.Core.DTOs
{
    public class PostDTO
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(100, ErrorMessage = "Title can't be longer than 100 characters")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Author is required")]
        public string Author { get; set; }

        public long CreatedDate { get; set; }

        public PostDTO()
        {

        }

        public PostDTO(Post post)
        {
            this.Id = post.Id;
            this.Title = post.Title;
            this.Description = post.Description;
            this.Author = post.Author;
            this.CreatedDate = post.CreatedDate;
        }

    }
}
