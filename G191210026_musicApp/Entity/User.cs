using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace G191210026_musicApp.Entity
{
    public class User
    {
        public int UserId { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        [EmailAddress(ErrorMessage ="Email adresini doğru biçimde giriniz")]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
