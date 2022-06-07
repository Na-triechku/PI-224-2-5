using Jobs.BLL.Interfaces;
using Jobs.BLL.Models;
using Microsoft.AspNetCore.Mvc;

namespace Jobs.PL.Controllers
{
    public class JobApplicationsController : Controller
    {
        private readonly IJobApplicationService _jobApplicationService;

        public JobApplicationsController(IJobApplicationService jobApplicationService)
        {
            _jobApplicationService = jobApplicationService;
        }

        [HttpGet]
        [Route("api/getJobApplications")]
        public async Task<List<JobApplicationModel>> GetAllJobApplicationsAsync()
        {
            return await _jobApplicationService.GetAllJobApplicationsAsync();
        }

        [HttpGet]
        [Route("api/getJobApplication")]
        public async Task<JobApplicationModel> GetJobApplicationAsync(int id)
        {
            return await _jobApplicationService.GetJobApplicationByIdAsync(id);
        }

        [HttpPost]
        [Route("api/addJobApplication")]
        public async Task AddJobApplicationAsync([FromBody] JobApplicationModel jobApplicationModel)
        {
            if (jobApplicationModel == null) return;
            await _jobApplicationService.AddJobApplicationAsync(jobApplicationModel);
        }

        [HttpPost]
        [Route("api/deleteJobApplication")]
        public async Task DeleteJobApplicationAsync([FromBody] int id)
        {
            if (id == null) return;
            await _jobApplicationService.DeleteJobApplicationAsync(id);
        }

        [HttpPost]
        [Route("api/editJobApplication")]
        public async Task EditJobApplicationAsync([FromBody] JobApplicationModel jobApplicationModel)
        {
            if (jobApplicationModel == null) return;
            await _jobApplicationService.EditJobApplicationAsync(jobApplicationModel);
        }
    }
}