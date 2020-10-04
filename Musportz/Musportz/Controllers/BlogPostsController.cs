using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Musportz.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace Musportz.Controllers
{
    public class BlogPostsController : Controller
    {
        private readonly MusportzContext _context;
        private UserManager<IdentityUser> _userManager;
        private IHostingEnvironment _webroot;
        

        public BlogPostsController(MusportzContext context, UserManager<IdentityUser> userManager, IHostingEnvironment webroot)
        {
            _context = context;
            _userManager = userManager;
            _webroot = webroot;
        }

        // GET: BlogPosts
        
        public async Task<IActionResult> Index()
        {
            var musportzContext = _context.BlogPost.Include(b => b.Category).Include(b => b.UserProfile);
            return View(await musportzContext.ToListAsync());
        }

        public async Task<IActionResult> Browse(int? id)
        {
            var musportzContext = _context.BlogPost.Where(b => b.UserProfileId == id).Include(b => b.Category).Include(b => b.UserProfile);
            return View(await _context.BlogPost.ToListAsync());
        }

        public async Task<IActionResult> BlogView(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogPost = await _context.BlogPost
                .FirstOrDefaultAsync(m => m.Id == id);
            if (blogPost == null)
            {
                return NotFound();
            }

            return View(blogPost);
        }

        



        [Authorize]
        public async Task<IActionResult> userBlogPost(int? id)
        {
            var musportzContext = _context.BlogPost.Where(b => b.UserProfileId == id).Include(b => b.Category).Include(b => b.UserProfile);
            return View(await musportzContext.ToListAsync());
        }

        // GET: BlogPosts/Details/5

        
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogPost = await _context.BlogPost
                .Include(b => b.Category)
                .Include(b => b.UserProfile)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (blogPost == null)
            {
                return NotFound();
            }

            return View(blogPost);
        }

        // GET: BlogPosts/Create
        [Authorize]
        public IActionResult Create(int id)
        {
            string userID = _userManager.GetUserId(User);
            UserProfile profile = _context.UserProfile.FirstOrDefault(p => p.UserAccountId == userID);
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "CategoryName");
            //ViewData["UserProfileId"] = new SelectList(_context.UserProfile, "Id", "FirstName");
            ViewBag.UserProfileId = profile.Id;
            return View();
        }

        // POST: BlogPosts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserProfileId,Title,CreatedAt,Content,CategoryId,ImagePath")] BlogPost blogPost, IFormFile FilePhoto)
        {
            if (FilePhoto.Length > 0)
            {

                string photoPath = _webroot.WebRootPath + "\\blogPhotos\\";
                var fileName = Path.GetFileName(FilePhoto.FileName);

                using (var stream = System.IO.File.Create(photoPath + fileName))
                {
                    await FilePhoto.CopyToAsync(stream);
                    blogPost.ImagePath = fileName;
                }
            }
            if (ModelState.IsValid)
            {
                _context.Add(blogPost);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "CategoryName", blogPost.CategoryId);
            //ViewData["UserProfileId"] = new SelectList(_context.UserProfile, "Id", "FirstName", blogPost.UserProfileId);
            return View(blogPost);
        }

        // GET: BlogPosts/Edit/5

        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogPost = await _context.BlogPost.FindAsync(id);
            if (blogPost == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "CategoryName", blogPost.CategoryId);
            ViewData["UserProfileId"] = new SelectList(_context.UserProfile, "Id", "FirstName", blogPost.UserProfileId);
            return View(blogPost);
        }

        // POST: BlogPosts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserProfileId,Title,CreatedAt,Content,CategoryId,ImagePath")] BlogPost blogPost)
        {
            if (id != blogPost.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(blogPost);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BlogPostExists(blogPost.Id))
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
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "CategoryName", blogPost.CategoryId);
            ViewData["UserProfileId"] = new SelectList(_context.UserProfile, "Id", "FirstName", blogPost.UserProfileId);
            return View(blogPost);
        }

        // GET: BlogPosts/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogPost = await _context.BlogPost
                .Include(b => b.Category)
                .Include(b => b.UserProfile)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (blogPost == null)
            {
                return NotFound();
            }

            return View(blogPost);
        }

        // POST: BlogPosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var blogPost = await _context.BlogPost.FindAsync(id);
            _context.BlogPost.Remove(blogPost);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BlogPostExists(int id)
        {
            return _context.BlogPost.Any(e => e.Id == id);
        }
    }
}
