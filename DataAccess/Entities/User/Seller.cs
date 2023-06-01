using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities.User
{
    public class Seller : IdentityUser
    {
        [Column(TypeName="decimal(8,2)")]
        [Required]
        public decimal Balance { get; set; }
    }
}
