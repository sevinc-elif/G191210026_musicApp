using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace G191210026_musicApp.Models
{
    public class GenresViewModel
    {
        public List<GenreViewModel> Genres { get; set; }
    }

    public class GenreViewModel
    {
        public int GenreId { get; set; }
        
        public string GenreName { get; set; }
        public List<MusicsViewModel> Musics { get; set; }
    }
}
