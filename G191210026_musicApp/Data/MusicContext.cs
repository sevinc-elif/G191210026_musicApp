using G191210026_musicApp.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace G191210026_musicApp.Data
{
    public class MusicContext: DbContext
    {
        public MusicContext(DbContextOptions<MusicContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
    }
}
