
using System.ComponentModel.DataAnnotations;


namespace ERPNet.Models
{
    public class RegisterModel
    {
        [Required]
        [StringLength ( 50 )]
        public string FirstName { get; set; }

        [Required]
        [StringLength ( 50 )]
        public string LastName { get; set; }

        [Required]
        [StringLength ( 50 )]
        public string Username { get; set; }

        [Required]
        [StringLength ( 50 )]
        public string Password { get; set; }

        public string Role { get; set; }
    }
}
