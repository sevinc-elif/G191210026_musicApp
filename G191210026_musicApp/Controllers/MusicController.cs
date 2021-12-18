using G191210026_musicApp.Data;
using G191210026_musicApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace G191210026_musicApp.Controllers
{
    public class MusicController : Controller
    {
        private readonly MusicContext _context;
        public MusicController(MusicContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
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
    }
}
