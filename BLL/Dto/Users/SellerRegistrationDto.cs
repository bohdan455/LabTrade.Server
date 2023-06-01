using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Dto.Users
{
    public class SellerRegistrationDto
    {
        [Required]
        [StringLength(256)]
        public string Login { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        [StringLength(256)]
        public string Password { get; set; } = string.Empty;
        [Required]
        [StringLength(256)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
