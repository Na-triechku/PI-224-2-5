using Jobs.WebClient.Interfaces;
using Jobs.WebClient.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Jobs.WebClient.Pages.Views.CV
{
    public class VacanciesCVsListModel : PageModel
    {
        private readonly ICVService _cvService;

        public List<CVViewModel> CVs { get; set; }

        public VacanciesCVsListModel(ICVService cvService)
        {
            _cvService = cvService;

            CVs = _cvService.GetAllCVs().Result;
        }

        public async Task OnGetAsync()
        {
            CVs = await _cvService.GetAllCVs();
        }
    }
}