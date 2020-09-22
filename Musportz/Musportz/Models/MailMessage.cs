using System;
using System.Collections.Generic;

namespace Musportz.Models
{
    public partial class MailMessage
    {
        public int Id { get; set; }
        public int? FromuserProfileId { get; set; }
        public int? TouserProfileId { get; set; }
        public string MessageTitle { get; set; }
        public string MessageText { get; set; }
        public bool IsRead { get; set; }

        public UserProfile FromuserProfile { get; set; }
        public UserProfile TouserProfile { get; set; }
    }
}
