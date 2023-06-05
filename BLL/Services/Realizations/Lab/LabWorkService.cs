using BLL.Dto.Lab;
using BLL.ExtensionMethods.Mapping;
using BLL.Services.Interfaces;
using DataAccess.Repositories.Realizations.Lab;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
using DataAccess.Repositories.Interfaces;

namespace BLL.Services.Realizations.Lab
{
    public class LabWorkService : ILabWorkService
    {
        private readonly ILabWorkRepository _labWorkRepository;
        private readonly IUniversityRepository _universityRepository;
        private readonly ILabFileService _labFileService;
        private readonly ISellerRepository _sellerRepository;

        public LabWorkService(ILabWorkRepository labWorkRepository,
            IUniversityRepository universityRepository,
            ILabFileService labFileService,
            ISellerRepository sellerRepository)
        {
            _labWorkRepository = labWorkRepository;
            _universityRepository = universityRepository;
            _labFileService = labFileService;
            _sellerRepository = sellerRepository;
        }
        public async Task Create(LabWorkDto labWorkDto, ClaimsPrincipal user)
        {
            var labwork = labWorkDto.ToLabWork();
            //TODO change it to another method
            var university = await _universityRepository.GetFirstAsync(u => u.Id == labWorkDto.UniversityId);
            labwork.University = university;

            var file = await _labFileService.Create(labWorkDto.ToLabFileDto());
            labwork.File = file;
            var seller = await _sellerRepository.GetFirstAsync(s => s.UserName == user.Identity.Name);
            labwork.Seller = seller;
            _labWorkRepository.Create(labwork);

        }
    }
}
