using System;
using System.Collections.Generic;

namespace Musportz.Models
{
    public partial class Category
    {
        public Category()
        {
            BlogPost = new HashSet<BlogPost>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public ICollection<BlogPost> BlogPost { get; set; }
    }
}
