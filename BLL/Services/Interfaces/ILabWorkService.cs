using BLL.Dto.Lab;

namespace BLL.Services.Interfaces
{
    public interface ILabWorkService
    {
        Task Create(LabWorkDto labWorkDto);
    }
}