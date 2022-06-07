using Jobs.BLL.Models;

namespace Jobs.BLL.Interfaces;

public interface IVacancyService
{
    Task<VacancyModel> GetVacancyByIdAsync(int id);

    Task<List<VacancyModel>> GetAllVacanciesAsync();

    Task AddVacancyAsync(VacancyModel vacancyModel);

    Task EditVacancyAsync(VacancyModel vacancyModel);

    Task DeleteVacancyAsync(int id);
}