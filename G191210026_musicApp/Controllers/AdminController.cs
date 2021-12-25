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
    [Authorize(Roles ="admin")]
    public class AdminController : Controller
    {
        private readonly MusicContext _context;
        public AdminController(MusicContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AdminMusicList()
        {
            return View(new AdminMusicsViewModel
            {
                Musics = _context.Musics
                .Include(m => m.Genres)
                .Select(m => new AdminMusicViewModel
                {
                    MusicId = m.MusicId,
                    MusicName = m.MusicName,
                    Singer = m.Singer,
                    ImageUrl = m.ImageUrl,
                    Genres = m.Genres.ToList()
                })
                .ToList()
            });
        }
        public IActionResult MusicCreate()
        {
            ViewBag.Genres = _context.Genres.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult MusicCreate(Music m,int[] genreIds)
        {
            
                m.Genres = new List<Genre>();
                foreach (var id in genreIds)
                {
                    m.Genres.Add(_context.Genres.FirstOrDefault(i => i.GenreId == id));
                }
                _context.Musics.Add(m);
                _context.SaveChanges();
                return RedirectToAction("AdminMusicList","Admin");
            
        }

        
        [HttpPost]
        public IActionResult MusicDelete(int musicId)
        {
            var entity = _context.Musics.Find(musicId);
            if (entity != null)
            {
                _context.Musics.Remove(entity);
                _context.SaveChanges();
            }
            return RedirectToAction("AdminMusicList","Admin");
        }

    }
}
