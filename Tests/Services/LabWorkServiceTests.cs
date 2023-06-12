using BLL.Dto.Lab;
using BLL.Services.Interfaces;
using BLL.Services.Realizations.Lab;
using DataAccess.Entities.Lab;
using DataAccess.Entities.User;
using DataAccess.Repositories.Interfaces;
using DataAccess.Repositories.Realizations.Lab;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests.Services
{
    public class LabWorkServiceTests
    {
        private readonly Mock<ILabWorkRepository> _labWorkRepository;
        private readonly Mock<IUniversityRepository> _universityRepository;
        private readonly Mock<ILabFileService> _labFileService;
        private readonly Mock<ISellerRepository> _sellerRepository;
        private readonly string _claimName = "test";
        private LabWorkService InitService()
        {
            return new LabWorkService(_labWorkRepository.Object, _universityRepository.Object, _labFileService.Object, _sellerRepository.Object); ;
        }
        private ClaimsPrincipal GetClaimsPrincipalWithClaimName()
        {
            ClaimsPrincipal user = new ClaimsPrincipal();
            var userIdentity = new ClaimsIdentity();
            userIdentity.AddClaim(new Claim(ClaimTypes.Name, _claimName));
            user.AddIdentity(userIdentity);
            return user;
        }
        public LabWorkServiceTests()
        {
            _labWorkRepository = new();
            _universityRepository = new();
            _labFileService = new();
            _sellerRepository = new();
        }

        [Fact]
		public async Task CreateAsync_GivenValidArguments_CreateFileAndLabWork()
		{
            // Arrange
            _labFileService.Setup(f => f.CreateAsync(It.IsAny<LabFileDto>()))
                .ReturnsAsync(new LabFile())
                .Verifiable();
            _labWorkRepository.Setup(l => l.Create(It.IsAny<LabWork>()))
                .Verifiable();
            var labWorkDto = new LabWorkDto();
            ClaimsPrincipal user = GetClaimsPrincipalWithClaimName();
            var service = InitService();

            // Act
            await service.CreateAsync(labWorkDto, user);

            // Assert
            _labFileService.VerifyAll();
            _labWorkRepository.VerifyAll();
        }
        [Fact]
        public async Task DeleteAsync_GivenValidArguments_DeleteLabWorkAndReturnTrue()
        {
            // Arrange
            int id = 1;
            var user = GetClaimsPrincipalWithClaimName();
            var listOfUsers = 
                new List<LabWork> { new LabWork {Id = id ,Seller = new Seller { UserName = _claimName } } }.AsQueryable();

            _labWorkRepository.Setup(l => l.Include(It.IsAny<Expression<Func<LabWork, object>>>()))
                .Returns(listOfUsers).Verifiable();
            _labWorkRepository.Setup(l => l.Delete(It.IsAny<LabWork>())).Verifiable();
            var service = InitService();
            // Act
            var result = await service.DeleteAsync(id, user);

            // Assert
            _labWorkRepository.VerifyAll();
            Assert.True(result);
        }

        [Fact]
        public async Task DeleteAsync_GivenUnexistingId_ReturnFalse()
        {
            // Arrange
            int id = 1;
            var user = GetClaimsPrincipalWithClaimName();
            _labWorkRepository.Setup(l => l.Include(It.IsAny<Expression<Func<LabWork,object>>>()))
                .Returns<IQueryable<LabWork>>(null);
            _labWorkRepository.Setup(l => l.Delete(It.IsAny<LabWork>()));
            var service = InitService();
            // Act
            var result = await service.DeleteAsync(id, user);

            // Assert
            Assert.False(result);
            _labWorkRepository.Verify(l => l.Delete(It.IsAny<LabWork>()), Times.Never);
        }
        [Fact]
        public async Task DeleteAsync_GivenNameNotOfSeller_ReturnFalse()
        {
            // Arrange
            int id = 1;
            var user = GetClaimsPrincipalWithClaimName();
            var listOfUsers =
                new List<LabWork> { new LabWork { Id = id, Seller = new Seller { UserName = "Other name" } } }.AsQueryable();
            _labWorkRepository.Setup(l => l.Delete(It.IsAny<LabWork>()));
            var service = InitService();

            // Act
            var result = await service.DeleteAsync(id, user);

            // Assert
            Assert.False(result);
            _labWorkRepository.Verify(l => l.Delete(It.IsAny<LabWork>()), Times.Never);
        }
    }
}
