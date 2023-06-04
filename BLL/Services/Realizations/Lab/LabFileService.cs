using BLL.Dto.Lab;
using BLL.Services.Interfaces;
using DataAccess.Entities.Lab;
using DataAccess.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Realizations.Lab
{
    public class LabFileService : ILabFileService
    {
        private readonly ILabFileRepository _labFileRepository;

        public LabFileService(ILabFileRepository labFileRepository)
        {
            _labFileRepository = labFileRepository;
        }
        public async Task<LabFile> Create(LabFileDto labFileDto)
        {
            var guid = Guid.NewGuid().ToString();
            var file = labFileDto.File;
            var extension = file.FileName.Split('.')?.Last();
            var labFile = new LabFile
            {
                PhysicalName = guid,
                DisplayName = labFileDto.Name
            };
            using (Stream fileStream = new FileStream(Path.Combine(LabFileSetting.Path, $"{guid}.{extension}"), FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
            _labFileRepository.Create(labFile);
            return labFile;
        }
    }
}
