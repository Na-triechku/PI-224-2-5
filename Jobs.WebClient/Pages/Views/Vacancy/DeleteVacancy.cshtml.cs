using Jobs.WebClient.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Jobs.WebClient.Pages.Views.Vacancy
{
    public class DeleteVacancyModel : PageModel
    {
        private IVacancyService _tourService;

        public DeleteVacancyModel(IVacancyService tourService)
        {
            _tourService = tourService;
        }

        public async Task OnGetAsync(int id)
        {
            if (id == null)
            {
                Response.Redirect("/Views/Home/Index");
                return;
            }

            await _tourService.DeleteVacancyAsync(id);
        }
    }
}