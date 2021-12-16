using G191210026_musicApp.Data;
using G191210026_musicApp.Models;
using Microsoft.AspNetCore.Mvc;
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

        public IActionResult MusicList()
        {
            return View(new MusicsViewModel
            {
                Musics = _context.Musics
                .Select(m => new MusicViewModel
                {
                    MusicId=m.MusicId,
                    MusicName=m.MusicName,
                    Singer=m.Singer,
                    ImageUrl=m.ImageUrl

                })
                .ToList()
            });
            
        }
    }
}
