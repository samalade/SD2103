using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Musportz.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace Musportz.Controllers
{
    public class PostCommentsController : Controller
    {
        private readonly MusportzContext _context;
        private UserManager<IdentityUser> _userManager;
        private IHostingEnvironment _webroot;

        public PostCommentsController(MusportzContext context, UserManager<IdentityUser> userManager, IHostingEnvironment webroot)
        {
            _context = context;
            _userManager = userManager;
            _webroot = webroot;
        }

        // GET: PostComments
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var musportzContext = _context.PostComments.Include(p => p.BlogPost).Include(p => p.UserProfile);
            return View(await musportzContext.ToListAsync());
        }

        // GET: PostComments/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postComments = await _context.PostComments
                .Include(p => p.BlogPost)
                .Include(p => p.UserProfile)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (postComments == null)
            {
                return NotFound();
            }

            return View(postComments);
        }

        // GET: PostComments/Create
        [Authorize]
        public IActionResult Create()
        {
            ViewData["BlogPostId"] = new SelectList(_context.BlogPost, "Id", "Content");
            ViewData["UserProfileId"] = new SelectList(_context.UserProfile, "Id", "FirstName");
            return View();
        }

        // POST: PostComments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserProfileId,CreatedAt,Content,BlogPostId")] PostComments postComments)
        {
            if (ModelState.IsValid)
            {
                _context.Add(postComments);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BlogPostId"] = new SelectList(_context.BlogPost, "Id", "Content", postComments.BlogPostId);
            ViewData["UserProfileId"] = new SelectList(_context.UserProfile, "Id", "FirstName", postComments.UserProfileId);
            return View(postComments);
        }

        // GET: PostComments/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postComments = await _context.PostComments.FindAsync(id);
            if (postComments == null)
            {
                return NotFound();
            }
            ViewData["BlogPostId"] = new SelectList(_context.BlogPost, "Id", "Content", postComments.BlogPostId);
            ViewData["UserProfileId"] = new SelectList(_context.UserProfile, "Id", "FirstName", postComments.UserProfileId);
            return View(postComments);
        }

        // POST: PostComments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserProfileId,CreatedAt,Content,BlogPostId")] PostComments postComments)
        {
            if (id != postComments.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(postComments);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostCommentsExists(postComments.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["BlogPostId"] = new SelectList(_context.BlogPost, "Id", "Content", postComments.BlogPostId);
            ViewData["UserProfileId"] = new SelectList(_context.UserProfile, "Id", "FirstName", postComments.UserProfileId);
            return View(postComments);
        }

        // GET: PostComments/Delete/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postComments = await _context.PostComments
                .Include(p => p.BlogPost)
                .Include(p => p.UserProfile)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (postComments == null)
            {
                return NotFound();
            }

            return View(postComments);
        }

        // POST: PostComments/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Administrator")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var postComments = await _context.PostComments.FindAsync(id);
            _context.PostComments.Remove(postComments);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostCommentsExists(int id)
        {
            return _context.PostComments.Any(e => e.Id == id);
        }
    }
}
