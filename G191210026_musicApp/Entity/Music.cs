using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace G191210026_musicApp.Entity
{
    public class Music
    {
        public int MusicId { get; set; }
        [Required]
        public string MusicName { get; set; }
        [Required]
        public string Singer { get; set; }

        public string ImageUrl { get; set; }
        [Required]
        public List<Genre> Genres { get; set; }
    }
}
