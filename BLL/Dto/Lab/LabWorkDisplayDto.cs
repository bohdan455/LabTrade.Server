using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Dto.Lab
{
    public class LabWorkDisplayDto
    {
        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string University { get; set; } = string.Empty;
        [Required]
        public decimal Price { get; set; }

    }
}
