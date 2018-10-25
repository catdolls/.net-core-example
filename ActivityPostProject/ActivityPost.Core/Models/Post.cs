using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ActivityPost.Core.Models
{
    [Table("post")]
    public class Post
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(100, ErrorMessage = "Title can't be longer than 100 characters")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Author is required")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Created Date is required")]
        public long CreatedDate { get; set; }

        [Required(ErrorMessage = "Updated Date is required")]
        public long UpdatedDate { get; set; }
    }
}
