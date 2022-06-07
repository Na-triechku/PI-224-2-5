using Jobs.WebClient.Interfaces;
using Jobs.WebClient.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Jobs.WebClient.Pages.Views.JobApplication
{
    public class JobApplicationModel : PageModel
    {
        private readonly IUserManagerService _userManagerService;
        private readonly ICVService _cvService;
        private readonly IJobApplicationService _jobApplicationService;
        private readonly IVacancyService _vacancyService;

        public int VacancyId { get; set; }

        public JobApplicationModel(ICVService cvService, IJobApplicationService jobApplicationService, IUserManagerService userManagerService, IVacancyService vacancyService)
        {
            _cvService = cvService;
            _jobApplicationService = jobApplicationService;
            _userManagerService = userManagerService;
            _vacancyService = vacancyService;
        }

        public async Task OnGetAsync(int vacancyId)
        {
            VacancyId = vacancyId;
        }

        public async Task OnPostAddJobApplicationAsync(string name, int vacancyId, int experience, string skills, double expectedSalary)
        {
            var cv = new CVViewModel
            {
                Name = name,
                Position = _vacancyService.GetVacancyByIdAsync(vacancyId).Result.Position,
                Experience = experience,
                ExpectedSalary = expectedSalary,
                Skills = skills
            };

            await _cvService.AddCVAsync(cv);

            cv = _cvService.GetAllCVs().Result.Find(c => c.Name == cv.Name && c.Position == cv.Position && c.Skills == cv.Skills);

            var jobApplication = new JobApplicationViewModel
            {
                VacancyId = vacancyId,
                UserId = _userManagerService.LoggedUser.Id,
                CVId = cv.Id,
                IsAccepted = false
            };

            await _jobApplicationService.AddJobApplicationAsync(jobApplication);

            Response.Redirect("/Views/Home/Index");
        }
    }
}