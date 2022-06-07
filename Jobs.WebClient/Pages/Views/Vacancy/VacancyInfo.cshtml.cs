using Jobs.WebClient.Interfaces;
using Jobs.WebClient.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Jobs.WebClient.Pages.Views.Vacancy
{
    public class VacancyInfoModel : PageModel
    {
        private IVacancyService _vacancyService;
        public VacancyViewModel VacancyViewModel { get; set; }

        public VacancyInfoModel(IVacancyService vacancyService)
        {
            _vacancyService = vacancyService;
        }

        public async Task OnGetAsync(int id)
        {
            VacancyViewModel = await _vacancyService.GetVacancyByIdAsync(id);
        }
    }
}