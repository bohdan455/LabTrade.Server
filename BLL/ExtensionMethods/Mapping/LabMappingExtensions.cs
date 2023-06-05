using BLL.Dto.Lab;
using DataAccess.Entities.Lab;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ExtensionMethods.Mapping
{
    public static class LabMappingExtensions
    {
        public static LabWork ToLabWork(this LabWorkDto labWorkDto)
        {
            return new LabWork
            {
                Title = labWorkDto.Title,
                Description = labWorkDto.Description,
                Price = labWorkDto.Price,
            };
        }
        public static LabFileDto ToLabFileDto(this LabWorkDto labWorkDto)
        {
            return new LabFileDto
            {
                Name = labWorkDto.Title,
                File = labWorkDto.File
            };
        }
    }
}
