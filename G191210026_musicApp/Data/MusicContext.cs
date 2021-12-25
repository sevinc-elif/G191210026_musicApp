using G191210026_musicApp.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace G191210026_musicApp.Data
{
    public class MusicContext: IdentityDbContext<User>
    {
        public MusicContext(DbContextOptions<MusicContext> options) : base(options)
        {

        }
        

        public DbSet<Music> Musics { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
