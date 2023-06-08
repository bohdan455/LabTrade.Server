using BLL.Dto.Lab;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Controllers;

namespace Tests.Controllers
{
    public class LabControllerTests
    {
        public readonly LabController _labController;
        public readonly Mock<ILabWorkService> _labWorkServiceMock = new();
        public LabControllerTests()
        {
            _labController = new LabController(_labWorkServiceMock.Object);
            
        }
        [Fact]
        public async Task GetByIdAsync_GivenIdOfExistingLab_ReturnThisLab()
        {
            // Arrange
            var idOfExistingLab = 3;
            var dto = new LabWorkDisplayDto()
            {
                Price = 100,
                Title = "Test",
                University = "WUNU"
            };
            _labWorkServiceMock.Setup(lw =>lw.GetByIdAsync(idOfExistingLab)).ReturnsAsync(dto);
            // Act
            var result = await _labController.GetByIdAsync(idOfExistingLab) as OkObjectResult;
            // Assert
            Assert.NotNull(result);
            Assert.Equal(dto, result.Value);
        }
        [Fact]
        public async Task GetByIdAsync_GivenIdOfNonExistentLab_ReturnNotFound()
        {
            // Arrange
            var idOfNonExistingLab = 4;
            _labWorkServiceMock.Setup(lw => lw.GetByIdAsync(idOfNonExistingLab)).ReturnsAsync((LabWorkDisplayDto)null);
            // Act
            var result = await _labController.GetByIdAsync(idOfNonExistingLab) as NotFoundResult;
            // Assert
            Assert.NotNull(result);
        }
    }
}
