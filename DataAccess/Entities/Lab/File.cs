using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities.Lab
{
    public class File
    {
        public int Id { get; set; }
        [MaxLength(255)]
        [Required]
        public string DisplayName { get; set; } = string.Empty;
        [MaxLength(255)]
        [Required]
        public string PhysicalName { get; set; } = string.Empty;
    }
}
