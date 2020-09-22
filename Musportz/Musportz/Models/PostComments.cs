using System;
using System.Collections.Generic;

namespace Musportz.Models
{
    public partial class PostComments
    {
        public int Id { get; set; }
        public int? UserProfileId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Content { get; set; }
        public int? BlogPostId { get; set; }

        public BlogPost BlogPost { get; set; }
        public UserProfile UserProfile { get; set; }
    }
}
