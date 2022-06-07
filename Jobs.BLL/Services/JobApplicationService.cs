using AutoMapper;
using Jobs.BLL.Interfaces;
using Jobs.BLL.Models;
using Jobs.DAL.Entities;
using Jobs.DAL.Interfaces;
using Jobs.DAL.Repositories;

namespace Jobs.BLL.Services;

public class JobApplicationService : IJobApplicationService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly Mapper _jobApplicationMapper;

    public JobApplicationService()
    {
        _unitOfWork = new UnitOfWork();

        var config = new MapperConfiguration(cfg => cfg.CreateMap<JobApplication, JobApplicationModel>().ReverseMap());
        _jobApplicationMapper = new Mapper(config);
    }

    public async Task<JobApplicationModel> GetJobApplicationByIdAsync(int id)
    {
        var jobApplication = await _unitOfWork.JobApplications.GetByIdAsync(id);
        var jobApplicationModel = _jobApplicationMapper.Map<JobApplication, JobApplicationModel>(jobApplication);
        return jobApplicationModel;
    }

    public async Task<List<JobApplicationModel>> GetAllJobApplicationsAsync()
    {
        var jobApplications = await _unitOfWork.JobApplications.GetAllAsync();
        var jobApplicationModels = _jobApplicationMapper.Map<List<JobApplication>, List<JobApplicationModel>>(jobApplications);

        return jobApplicationModels;
    }

    public async Task AddJobApplicationAsync(JobApplicationModel jobApplicationModel)
    {
        var jobApplication = _jobApplicationMapper.Map<JobApplicationModel, JobApplication>(jobApplicationModel);
        await _unitOfWork.JobApplications.CreateAsync(jobApplication);
    }

    public async Task EditJobApplicationAsync(JobApplicationModel jobApplicationModel)
    {
        var jobApplication = _jobApplicationMapper.Map<JobApplicationModel, JobApplication>(jobApplicationModel);
        await _unitOfWork.JobApplications.UpdateAsync(jobApplication);
    }

    public async Task DeleteJobApplicationAsync(int id)
    {
        var jobApplicationsList = await _unitOfWork.JobApplications.FindAsync(t => t.Id == id);
        var jobApplication = jobApplicationsList.First();
        await _unitOfWork.JobApplications.DeleteAsync(jobApplication);
    }
}