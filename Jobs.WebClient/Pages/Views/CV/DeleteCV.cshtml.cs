using Jobs.WebClient.Interfaces;
using Jobs.WebClient.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Jobs.WebClient.Pages.Views.CV
{
    public class DeleteCVModel : PageModel
    {
        private ICVService _cvService;
        public List<CVViewModel> CVs { get; set; }

        public DeleteCVModel(ICVService cvService)
        {
            _cvService = cvService;
            CVs = _cvService.GetAllCVs().Result;
        }

        public async Task OnGetAsync()
        {
            CVs = await _cvService.GetAllCVs();
        }

        public async Task OnPostDeleteCVAsync(int id)
        {
            await _cvService.DeleteCVAsync(id);
            Response.Redirect("/Views/Home/Index");
        }
    }
}