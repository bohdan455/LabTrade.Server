using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Dto.Users
{
    public class SellerLoginDto
    {
        [Required]
        [StringLength(256)]
        public string Login { get; set; } = string.Empty;
        [Required]
        [StringLength(256)]
        public string Password { get; set; } = string.Empty;
    }
}
