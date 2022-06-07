using Jobs.WebClient.Interfaces;
using Jobs.WebClient.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Jobs.WebClient.Pages.Views.CV
{
    public class FindCVsByVacancyModel : PageModel
    {
        private readonly IVacancyService _vacancyService;
        private readonly ICVService _cvService;
        private readonly IJobApplicationService _jobApplicationService;

        public List<CVViewModel> CVs { get; set; }

        public FindCVsByVacancyModel(IVacancyService vacancyService, ICVService cvService, IJobApplicationService jobApplicationService)
        {
            _vacancyService = vacancyService;
            _cvService = cvService;
            _jobApplicationService = jobApplicationService;
        }

        public async Task OnGetAsync(int vacancyId)
        {
            CVs = new List<CVViewModel>();

            var vacancy = await _vacancyService.GetVacancyByIdAsync(vacancyId);

            var jobApplications = await _jobApplicationService.GetAllJobApplications();

            if (jobApplications.Any())
            {
                var vacancyJobApplications = jobApplications.Where(j => j.VacancyId == vacancy.Id).ToList();

                if (vacancyJobApplications.Any())
                {
                    var cvsList = await _cvService.GetAllCVs();

                    if (cvsList.Any())
                    {
                        foreach (var j in vacancyJobApplications)
                        {
                            if (j.IsAccepted == false)
                            {
                                CVs = CVs.Concat(cvsList.Where(c => c.Id == j.CVId)).ToList();
                            }
                        }
                    }
                }
            }
        }

        public async Task OnPostAcceptCVAsync(int id)
        {
            CVs = new List<CVViewModel>();

            var jobApplications = await _jobApplicationService.GetAllJobApplications();

            var jobApplication = jobApplications.Where(j => j.CVId == id).FirstOrDefault();
            jobApplication.IsAccepted = true;

            await _jobApplicationService.EditJobApplicationAsync(jobApplication);

            Response.Redirect("/Views/Home/index");
        }
    }
}