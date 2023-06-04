using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Dto.Lab
{
    public class LabFileDto
    {
        public string Name { get; set; }
        public IFormFile File { get; set; }
    }
}
