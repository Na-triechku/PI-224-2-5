using Jobs.BLL.Models;

namespace Jobs.BLL.Interfaces;

public interface ICVService
{
    Task<CVModel> GetCVByIdAsync(int id);

    Task<List<CVModel>> GetAllCVsAsync();

    Task AddCVAsync(CVModel cvModel);

    Task EditCVAsync(CVModel cvModel);

    Task DeleteCVAsync(int id);
}