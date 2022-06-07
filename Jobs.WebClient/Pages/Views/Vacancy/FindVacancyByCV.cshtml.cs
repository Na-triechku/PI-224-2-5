using Jobs.WebClient.Interfaces;
using Jobs.WebClient.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Serilog;

namespace Jobs.WebClient.Pages.Views.Vacancy
{
    public class FindVacancyByCVModel : PageModel
    {
        private readonly IVacancyService _vacancyService;
        private readonly ICVService _cvService;
        private readonly IJobApplicationService _jobApplicationService;

        public List<VacancyViewModel> Vacancies { get; set; }

        public FindVacancyByCVModel(IVacancyService vacancyService, ICVService cvService, IJobApplicationService jobApplicationService)
        {
            _vacancyService = vacancyService;
            _cvService = cvService;
            _jobApplicationService = jobApplicationService;
        }

        public async Task OnGetAsync(int vacancyId)
        {
            Vacancies = new List<VacancyViewModel>();

            var cv = await _cvService.GetCVByIdAsync(vacancyId);

            var vacanciesList = await _vacancyService.GetAllVacanciesAsync();

            Vacancies = vacanciesList.Where(v => v.Position.ToLower().Contains(cv.Position.ToLower())).ToList();
        }
    }
}