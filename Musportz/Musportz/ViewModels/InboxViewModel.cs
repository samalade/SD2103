using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Musportz.Models;

namespace Musportz.ViewModels
{
    public class InboxViewModel
    {

        public IEnumerable<MailMessage> mailMessages;
        public IEnumerable<UserProfile> fromProfiles;
    }
}
