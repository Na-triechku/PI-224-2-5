using Jobs.WebClient.Interfaces;
using Jobs.WebClient.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Jobs.WebClient.Pages.Views.Vacancy
{
    public class EditVacancyModel : PageModel
    {
        private IVacancyService _vacancyService;

        public int Id { get; set; }

        public EditVacancyModel(IVacancyService vacancyService)
        {
            _vacancyService = vacancyService;
        }

        public void OnGet(int id)
        {
            Id = id;
        }

        public async Task OnPostEditVacancyAsync(int id, string name, string position, int requiredExperience, string requiredSkills, DateTime startDate, double salary)
        {
            if (id == null || name == null || position == null || requiredExperience == null || requiredSkills == null || startDate == null || salary == null)
            {
                Response.Redirect("/Views/Home/Index");
                return;
            }

            await _vacancyService.EditVacancyAsync(new VacancyViewModel
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