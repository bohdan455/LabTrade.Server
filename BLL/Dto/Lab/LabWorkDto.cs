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
        public string Title { get; set; } = string.Empty;
        [MaxLength(500)]
        [Required]
        public string Description { get; set; } = string.Empty;
        [Required]
        [Column(TypeName = "decimal(8,2)")]
        public decimal Price { get; set; }
        [Required]
        public int UniversityId { get; set; }
        [Required]
        public IFormFile File { get; set; }

    }
}
