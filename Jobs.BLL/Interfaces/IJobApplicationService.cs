using Jobs.BLL.Models;

namespace Jobs.BLL.Interfaces;

public interface IJobApplicationService
{
    Task<JobApplicationModel> GetJobApplicationByIdAsync(int id);

    Task<List<JobApplicationModel>> GetAllJobApplicationsAsync();

    Task AddJobApplicationAsync(JobApplicationModel jobApplicationModel);

    Task EditJobApplicationAsync(JobApplicationModel jobApplicationModel);

    Task DeleteJobApplicationAsync(int id);
}