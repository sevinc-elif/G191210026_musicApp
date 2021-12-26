using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace G191210026_musicApp.Entity
{
    public class Comment
    {
        public int CommentId { get; set; }

        [Required]
        public string Comments { get; set; }

        public DateTime DateTime { get; set; }

        public Music Music { get; set; }

        public int MusicId { get; set; }

        [Required]
        public string UserName { get; set; }
    }
}
