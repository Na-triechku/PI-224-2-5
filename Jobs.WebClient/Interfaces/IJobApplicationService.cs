using Jobs.WebClient.Models;

namespace Jobs.WebClient.Interfaces;

public interface IJobApplicationService
{
    Task<JobApplicationViewModel> GetJobApplicationByIdAsync(int id);

    Task<List<JobApplicationViewModel>> GetAllJobApplications();

    Task AddJobApplicationAsync(JobApplicationViewModel jobApplicationViewModel);

    Task EditJobApplicationAsync(JobApplicationViewModel jobApplicationViewModel);

    Task DeleteJobApplicationAsync(int id);
}