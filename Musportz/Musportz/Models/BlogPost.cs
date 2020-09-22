using System;
using System.Collections.Generic;

namespace Musportz.Models
{
    public partial class BlogPost
    {
        public BlogPost()
        {
            PostComments = new HashSet<PostComments>();
        }

        public int Id { get; set; }
        public int? UserProfileId { get; set; }
        public string Title { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Content { get; set; }
        public int? CategoryId { get; set; }
        public string ImagePath { get; set; }

        public Category Category { get; set; }
        public UserProfile UserProfile { get; set; }
        public ICollection<PostComments> PostComments { get; set; }
    }
}
