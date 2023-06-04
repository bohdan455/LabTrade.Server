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
                Name = labWorkDto.Name,
                Description = labWorkDto.Description,
                Number = labWorkDto.Number,
                Price = labWorkDto.Price,
                Subject = labWorkDto.Subject,
                Type = labWorkDto.Type,
                Year = labWorkDto.Year
            };
        }
        public static LabFileDto ToLabFileDto(this LabWorkDto labWorkDto)
        {
            var name = $"{labWorkDto.Year} курс {labWorkDto.Subject} {labWorkDto.Type}-{labWorkDto.Number}";
            return new LabFileDto
            {
                Name = name,
                File = labWorkDto.File
            };
        }
    }
}
