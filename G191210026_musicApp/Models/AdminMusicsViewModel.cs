using G191210026_musicApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace G191210026_musicApp.Models
{
    public class AdminMusicsViewModel
    {
        public List<AdminMusicViewModel> Musics { get; set; }
    }

    public class AdminMusicViewModel
    {
        public int MusicId { get; set; }
        public string MusicName { get; set; }
        public string Singer { get; set; }
        public string ImageUrl { get; set; }
        public List<Genre> Genres { get; set; }
    }

    public class AdminEditMusicViewModel
    {
        public int MusicId { get; set; }
        public string MusicName { get; set; }
        public string Singer { get; set; }
        
        public List<Genre> SelectedGenres { get; set; }
    }
}
