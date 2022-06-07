using Jobs.WebClient.Interfaces;
using Jobs.WebClient.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Jobs.WebClient.Pages.Views.Home
{
    public class IndexModel : PageModel
    {
        private IUserManagerService _userManager;
        private IVacancyService _vacancyService;
        public List<VacancyViewModel?> Vacancies { get; set; }

        public IndexModel(IUserManagerService userManager, IVacancyService vacancyService)
        {
            _userManager = userManager;
            _vacancyService = vacancyService;

            if (Vacancies == null)
            {
                Vacancies = _vacancyService.GetAllVacanciesAsync().Result;
            }
        }

        public async Task OnGetAsync(bool logout = false, string sort = "none")
        {
            if (logout)
            {
                await _userManager.LogoutAsync();
                Response.Redirect("/Views/Home/Index");
            }

            if (Vacancies == null)
            {
                Vacancies = await _vacancyService.GetAllVacanciesAsync();
            }

            if (Vacancies != null)
            {
                switch (sort)
                {
                    case "position":
                        Vacancies = Vacancies.OrderBy(v => v.Position).ToList();
                        break;

                    case "requiredExperience":
                        Vacancies = Vacancies.OrderBy(v => v.RequiredExperience).ToList();
                        break;

                    case "date":
                        Vacancies = Vacancies.OrderBy(v => v.StartDate).ToList();
                        break;

                    case "salary":
                        Vacancies = Vacancies.OrderBy(v => v.Salary).ToList();
                        break;

                    case "positionDescending":
                        Vacancies = Vacancies.OrderByDescending(v => v.Position).ToList();
                        break;

                    case "requiredExperienceDescending":
                        Vacancies = Vacancies.OrderByDescending(v => v.RequiredExperience).ToList();
                        break;

                    case "dateDescending":
                        Vacancies = Vacancies.OrderByDescending(v => v.StartDate).ToList();
                        break;

                    case "salaryDescending":
                        Vacancies = Vacancies.OrderByDescending(v => v.Salary).ToList();
                        break;
                }
            }
        }

        public async Task OnPostSearchNameAsync(string search)
        {
            if (Vacancies != null)
            {
                if (search != "")
                {
                    Vacancies = Vacancies.Where(v => v.Name.ToLower().Contains(search.ToLower())).ToList();
                }
            }
            else
            {
                Vacancies = await _vacancyService.GetAllVacanciesAsync();
                Vacancies = Vacancies.Where(v => v.Name.ToLower().Contains(search.ToLower())).ToList();
            }
        }

        public async Task OnPostSearchPositionAsync(string search)
        {
            if (Vacancies != null)
            {
                if (search != "")
                {
                    Vacancies = Vacancies.Where(v => v.Position.ToLower().Contains(search.ToLower())).ToList();
                }
            }
            else
            {
                Vacancies = await _vacancyService.GetAllVacanciesAsync();
                Vacancies = Vacancies.Where(v => v.Position.ToLower().Contains(search.ToLower())).ToList();
            }
        }

        public async Task OnPostSearchSalaryAsync(double search)
        {
            if (Vacancies != null)
            {
                if (search != null)
                {
                    Vacancies = Vacancies.Where(v => v.Salary == search).ToList();
                }
            }
            else
            {
                Vacancies = await _vacancyService.GetAllVacanciesAsync();
                Vacancies = Vacancies.Where(v => v.Salary == search).ToList();
            }
        }

        public async Task OnPostSearchExperienceAsync(int search)
        {
            if (Vacancies != null)
            {
                if (search != null)
                {
                    Vacancies = Vacancies.Where(v => v.RequiredExperience == search).ToList();
                }
            }
            else
            {
                Vacancies = await _vacancyService.GetAllVacanciesAsync();
                Vacancies = Vacancies.Where(t => t.RequiredExperience == search).ToList();
            }
        }
    }
}