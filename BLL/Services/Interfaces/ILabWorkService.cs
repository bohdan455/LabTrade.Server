using BLL.Dto.Lab;
using System.Security.Claims;

namespace BLL.Services.Interfaces
{
    public interface ILabWorkService
    {
        Task Create(LabWorkDto labWorkDto, ClaimsPrincipal user);
        Task<bool> Delete(int id, ClaimsPrincipal user);
    }
}