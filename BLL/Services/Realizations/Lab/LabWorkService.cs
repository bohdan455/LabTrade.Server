using BLL.Dto.Lab;
using BLL.ExtensionMethods.Mapping;
using BLL.Services.Interfaces;
using DataAccess.Repositories.Interfaces;
using DataAccess.Repositories.Realizations.Lab;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

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
        public async Task CreateAsync(LabWorkDto labWorkDto, ClaimsPrincipal user)
        {
            var labwork = labWorkDto.ToLabWork();
            //TODO change it to another method
            var university = await _universityRepository.GetFirstAsync(u => u.Id == labWorkDto.UniversityId);
            labwork.University = university;

            var file = await _labFileService.CreateAsync(labWorkDto.ToLabFileDto());
            labwork.File = file;
            var seller = await _sellerRepository.GetFirstAsync(s => s.UserName == user.Identity.Name);
            labwork.Seller = seller;
            _labWorkRepository.Create(labwork);

        }
        public async Task<bool> DeleteAsync(int id, ClaimsPrincipal user)
        {
            var username = user.Identity.Name;
            var labwork = _labWorkRepository.Include(u => u.Seller).FirstOrDefault(u => u.Id == id);
            if(labwork is null) return false;

            if (labwork.Seller.UserName != username) return false;
            _labWorkRepository.Delete(labwork);

            return true;
        }
        public IEnumerable<LabWorkDisplayDto> GetRange(int page, int step)
        {
            var numberOfElementToSkip = step * (page - 1);
            return _labWorkRepository
                .GetInRange(numberOfElementToSkip, step)
                .Include(l => l.University)
                .Select(l => new LabWorkDisplayDto
                {
                    Title = l.Title,
                    Price = l.Price,
                    University = l.University.Name
                });
        }
        public async Task<LabWorkDisplayDto> GetByIdAsync(int id)
        {
            var labWork = await _labWorkRepository.Include(l => l.University)?.FirstOrDefaultAsync(l => l.Id == id);

            if (labWork is null) return null;

            var labWorkDisplayDto = new LabWorkDisplayDto
            {
                Title = labWork.Title,
                Price = labWork.Price,
                University = labWork.University.Name
            };
            return labWorkDisplayDto;
        }
    }
}
