using G191210026_musicApp.Data;
using G191210026_musicApp.Entity;
using G191210026_musicApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace G191210026_musicApp.Controllers
{
    [Authorize]
    public class MusicController : Controller
    {
        private readonly MusicContext _context;
        public MusicController(MusicContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var bilgi = _context.Musics.OrderByDescending(i => i.FavCount).Take(10);
            var model = new MusicsViewModel()
            {
                Musics = bilgi.ToList()

            };
            return View(model);
        }

        public IActionResult MusicList(int? id, string q)
        {
            var musics = _context.Musics.AsQueryable();
            if (id != null)
            {
                musics = musics
                    .Include(m => m.Genres)
                    .Where(m => m.Genres.Any(g => g.GenreId == id));
            }
            if (!string.IsNullOrEmpty(q))
            {
                musics = musics.Where(i => i.MusicName.ToLower().Contains(q.ToLower())
                || i.Singer.ToLower().Contains(q.ToLower()));
            }
            var model = new MusicsViewModel()
            {
                Musics = musics.ToList()

            };
            return View(model);

        }
        [HttpPost]
        public IActionResult MusicFav(int musicId)
        {
            var entity = _context.Musics.Find(musicId);
            if (entity != null)
            {

                entity.FavCount += 1;
                _context.SaveChanges();
            }
            return RedirectToAction("MusicList","Music");
        }

        public IActionResult AddComment()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddComment(Comment comment)
        {
            comment.DateTime = DateTime.Now;
            _context.Comments.Add(comment);
            _context.SaveChanges();
            return RedirectToAction("Comment", "Music", new { @id = comment.MusicId });
            
        }
        //public IActionResult Comment(int musicId)
        //{
            
        //    var comments = _context.Comments.AsQueryable();
                
            
        //    var model = new CommentsViewModel()
        //    {
        //        Comments = comments.ToList()

        //    };
        //    return View(model);
            
        //}
    }
}
