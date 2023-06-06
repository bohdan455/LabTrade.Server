using BLL.Dto.Lab;
using System.Security.Claims;

namespace BLL.Services.Interfaces
{
    public interface ILabWorkService
    {
        Task CreateAsync(LabWorkDto labWorkDto, ClaimsPrincipal user);
        Task<bool> DeleteAsync(int id, ClaimsPrincipal user);
        Task<LabWorkDisplayDto> GetByIdAsync(int id);
        IEnumerable<LabWorkDisplayDto> GetRange(int page, int step);
    }
}