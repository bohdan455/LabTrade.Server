using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Dto.Lab
{
    public class LabWorkDto
    {
        [MaxLength(255)]
        [Required]
        public string Name { get; set; } = string.Empty;
        [MaxLength(500)]
        [Required]
        public string Description { get; set; } = string.Empty;
        [Required]
        [Column(TypeName = "decimal(8,2)")]
        public decimal Price { get; set; }
        [Required]
        public int UniversityId { get; set; }
        [Required]
        [Range(0,10)]
        public int Year { get; set; }
        [MaxLength(255)]
        [Required]
        public string Subject { get; set; } = string.Empty;
        [MaxLength(255)]
        [Required]
        public string Type { get; set; } = string.Empty;
        [MaxLength(20)]
        [Required]
        public string Number { get; set; } = string.Empty;
        [Required]
        public IFormFile File { get; set; }

    }
}
