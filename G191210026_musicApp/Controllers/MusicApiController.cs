using G191210026_musicApp.Data;
using G191210026_musicApp.Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace G191210026_musicApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicApiController : ControllerBase
    {
        private readonly MusicContext _context;
        public MusicApiController(MusicContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Music> Get()
        {

            return _context.Musics.ToList();
        }

        
    }
}
