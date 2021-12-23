using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using wsei_asp.net.Data;
using wsei_asp.net.Models;

namespace wsei_asp.net.Controllers
{
    public class PostController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PostController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = _context.Posts
                .Include(p => p.Comments)
                .Single(m => m.Id == id & m.Published == true);

            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }



        public IActionResult AddComment(int? id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddComment([Bind("Content,Email,CreatedAt,Published")] Comment comment, int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = _context.Posts
                .Single(m => m.Id == id & m.Published == true);

            if (post == null)
            {
                return NotFound();
            }

            comment.Post = post;

            if (ModelState.IsValid)
            {
                _context.Add(comment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Detail), new { id = id });
            }
            return View(comment);
        }
    }
}
