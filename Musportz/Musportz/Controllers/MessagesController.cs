using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Musportz.Models;
using Musportz.ViewModels;

namespace Musportz.Controllers
{
    public class MessagesController : Controller
    {
        private MusportzContext _context;
        private UserManager<IdentityUser> _userManager;

        public MessagesController(MusportzContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Inbox()
        {
            UserProfile profile = _context.UserProfile.FirstOrDefault(id =>
                id.UserAccountId == _userManager.GetUserId(User));


            InboxViewModel inbox = new InboxViewModel();
            inbox.mailMessages = _context.MailMessage.Where(to => to.TouserProfileId == profile.Id).ToList();

            List<UserProfile> fromList = new List<UserProfile>();
            foreach (var msg in inbox.mailMessages)
            {
                fromList.Add(_context.UserProfile.FirstOrDefault(from => from.Id == msg.FromuserProfileId));

            }

            inbox.fromProfiles = fromList;
            return View(inbox);
        }

        public IActionResult NewMessage(int id)
        {
            ViewBag.TouserProfileId = id;
            return View();
        }

        public IActionResult Read(int id)
        {
            MailMessage mail = _context.MailMessage.FirstOrDefault(m => m.Id == id);
            mail.IsRead = true;
            _context.Update(mail);
            _context.SaveChanges();
            return View(mail);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Send([Bind("MessageTitle, MessageText")] MailMessage mail, int toProfileId)
        {

            UserProfile fromUser = _context.UserProfile.FirstOrDefault(p => p.UserAccountId == _userManager.GetUserId(User));
            mail.FromuserProfileId = fromUser.Id;
            mail.IsRead = false;
            mail.FromuserProfile = fromUser;
            mail.TouserProfileId = toProfileId;

            _context.Add(mail);
            _context.SaveChanges();

            return RedirectToAction("Browse", "UserProfiles");
        }
    }

}