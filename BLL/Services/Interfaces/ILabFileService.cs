using BLL.Dto.Lab;
using DataAccess.Entities.Lab;

namespace BLL.Services.Interfaces
{
    public interface ILabFileService
    {
        Task<LabFile> CreateAsync(LabFileDto labFileDto);
    }
}