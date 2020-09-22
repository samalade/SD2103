using System;
using System.Collections.Generic;

namespace Musportz.Models
{
    public partial class UserProfile
    {
        public UserProfile()
        {
            BlogPost = new HashSet<BlogPost>();
            MailMessageFromuserProfile = new HashSet<MailMessage>();
            MailMessageTouserProfile = new HashSet<MailMessage>();
            PostComments = new HashSet<PostComments>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Bio { get; set; }
        public string UserAccountId { get; set; }
        public string DisplayName { get; set; }
        public string PhotoPath { get; set; }
        public DateTime RegisteredAt { get; set; }

        public ICollection<BlogPost> BlogPost { get; set; }
        public ICollection<MailMessage> MailMessageFromuserProfile { get; set; }
        public ICollection<MailMessage> MailMessageTouserProfile { get; set; }
        public ICollection<PostComments> PostComments { get; set; }
    }
}
