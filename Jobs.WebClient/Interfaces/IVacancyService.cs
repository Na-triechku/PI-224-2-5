using Jobs.WebClient.Models;

namespace Jobs.WebClient.Interfaces;

public interface IVacancyService
{
    Task AddVacancyAsync(VacancyViewModel vacancyViewModel);

    Task EditVacancyAsync(VacancyViewModel vacancyViewModel);

    Task DeleteVacancyAsync(int id);

    Task<VacancyViewModel> GetVacancyByIdAsync(int id);

    Task<List<VacancyViewModel?>> GetAllVacanciesAsync();
}