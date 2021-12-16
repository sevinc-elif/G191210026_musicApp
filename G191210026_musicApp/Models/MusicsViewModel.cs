using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace G191210026_musicApp.Models
{
    public class MusicsViewModel
    {
        public List<MusicViewModel> Musics { get; set; }

    }
    public class MusicViewModel
    {
        public int MusicId { get; set; }
        public string MusicName { get; set; }
        public string Singer { get; set; }
        public string ImageUrl { get; set; }
        
    }
}
