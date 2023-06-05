using DataAccess.Entities.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities.Lab
{
    public class LabWork
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(255)]
        [Required]
        public string Title { get; set; } = string.Empty;
        [MaxLength(500)]
        [Required]
        public string Description { get; set; } = string.Empty;
        [Required]
        [Column(TypeName = "decimal(8,2)")]
        public decimal Price { get; set; }
        [Required]
        public University University { get; set; }        
        [Required]
        public LabFile File { get; set; }
        [MaxLength(450)]
        [Required]
        public string SellerId { get; set; }
        [Required]
        public Seller Seller{ get; set; }

    }
}
