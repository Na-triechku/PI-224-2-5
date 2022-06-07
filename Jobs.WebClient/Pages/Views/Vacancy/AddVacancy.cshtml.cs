using Jobs.WebClient.Interfaces;
using Jobs.WebClient.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Jobs.WebClient.Pages.Views.Vacancy
{
    public class AddVacancyModel : PageModel
    {
        private IVacancyService _vacancyService;

        public AddVacancyModel(IVacancyService vacancyService)
        {
            _vacancyService = vacancyService;
        }

        public void OnGet()
        {
        }

        public async Task OnPostAddVacancyAsync(string name, string position, int requiredExperience, string requiredSkills, DateTime startDate, double salary)
        {
            if (name == null || position == null || requiredExperience == null || requiredSkills == null || startDate == null || salary == null)
            {
                Response.Redirect("/Views/Tour/AddVacancy");
                return;
            }

            await _vacancyService.AddVacancyAsync(new VacancyViewModel
            {
                Name = name,
                Position = position,
                RequiredExperience = requiredExperience,
                RequiredSkills = requiredSkills,
                StartDate = startDate,
                Salary = salary
            });

            Response.Redirect("/Views/Home/Index");
        }
    }
}