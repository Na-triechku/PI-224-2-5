using Jobs.WebClient.Models;

namespace Jobs.WebClient.Interfaces;

public interface ICVService
{
    Task<CVViewModel> GetCVByIdAsync(int id);

    Task<List<CVViewModel>> GetAllCVs();

    Task AddCVAsync(CVViewModel cvViewModel);

    Task EditCVAsync(CVViewModel cvViewModel);

    Task DeleteCVAsync(int id);
}