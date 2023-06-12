using DataAccess.Entities.Lab;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities.Money
{
    public class Transaction
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public LabWork PurchasedLabWork { get; set; }
        [Required]
        [Column(TypeName = "decimal(8,2)")]
        public decimal Amount { get; set; }
        [Required]
        public DateTime DateOfTransaction { get; set; }
        [Required]
        [MaxLength(500)]
        public string Description { get; set; } = string.Empty;
    }
}
