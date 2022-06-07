using Jobs.WebClient.Interfaces;
using Jobs.WebClient.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Jobs.WebClient.Pages.Views.CV
{
    public class AddCVModel : PageModel
    {
        private ICVService _cvManager;

        public AddCVModel(ICVService cvManager)
        {
            _cvManager = cvManager;
        }

        public void OnGet()
        {
        }

        public async Task OnPostAddCVAsync(string name, string position, int experience, string skills, double expectedSalary)
        {
            if (name == null || position == null || experience == null || skills == null || expectedSalary == null)
            {
                Response.Redirect("/Views/Hotel/AddCV");
                return;
            }
            await _cvManager.AddCVAsync(new CVViewModel
            {
                Name = name,
                ExpectedSalary = expectedSalary,
                Experience = experience,
                Skills = skills,
                Position = position
            });

            Response.Redirect("/Views/Home/Index");
        }
    }
}