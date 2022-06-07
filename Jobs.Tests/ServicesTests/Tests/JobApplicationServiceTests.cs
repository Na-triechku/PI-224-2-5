using Jobs.DAL.Entities;
using Jobs.DAL.Interfaces;
using Jobs.Tests.ServicesTests.TestsData;
using Moq;
using Newtonsoft.Json;

namespace Jobs.Tests.ServicesTests.Tests;

public class JobApplicationServiceTests
{
    [Fact]
    public void GetAllJobApplicationsAsyncReturnJobApplicationsList()
    {
        //Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        unitOfWorkMock.Setup(unitOfWork => unitOfWork.JobApplications.GetAllAsync()).Returns(GetTestJobApplicationsAsync());

        //Act
        var jobApplications = unitOfWorkMock.Object.JobApplications.GetAllAsync().Result;

        //Assert
        Assert.NotNull(jobApplications);
        Assert.IsType<List<JobApplication>>(jobApplications);
    }

    [Theory]
    [ClassData(typeof(EditJobApplicationTestsData))]
    public async Task EditJobApplicationAsync(JobApplication jobApplication, Task expected)
    {
        //Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        unitOfWorkMock.Setup(unitOfWork => unitOfWork.JobApplications.UpdateAsync(jobApplication)).Returns(EditTestJobApplication(jobApplication));

        //Act
        var actual = unitOfWorkMock.Object.JobApplications.UpdateAsync(jobApplication);

        //Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [ClassData(typeof(AddJobApplicationTestsData))]
    public async Task AddJobApplicationAsync(JobApplication jobApplication, JobApplication expected)
    {
        //Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        unitOfWorkMock.Setup(unitOfWork => unitOfWork.JobApplications.CreateAsync(jobApplication)).Returns(AddTestJobApplicationAsync(jobApplication));

        //Act
        var actual = await unitOfWorkMock.Object.JobApplications.CreateAsync(jobApplication);
        var actualJson = JsonConvert.SerializeObject(actual);
        var expectedJson = JsonConvert.SerializeObject(expected);

        //Assert
        Assert.Equal(expectedJson, actualJson);
    }

    [Theory]
    [ClassData(typeof(DeleteJobApplicationTestsData))]
    public async Task DeleteJobApplicationAsync(JobApplication jobApplication, Task expected)
    {
        //Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        unitOfWorkMock.Setup(unitOfWork => unitOfWork.JobApplications.DeleteAsync(jobApplication)).Returns(DeleteTestJobApplication(jobApplication));

        //Act
        var actual = unitOfWorkMock.Object.JobApplications.DeleteAsync(jobApplication);

        //Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [ClassData(typeof(GetJobApplicationByIdTestsData))]
    public async Task GetJobApplicationByIdAsyncReturnJobApplication(int id, JobApplication expected)
    {
        //Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        unitOfWorkMock.Setup(unitOfWork => unitOfWork.JobApplications.GetByIdAsync(id)).Returns(GetTestJobApplicationByIdAsync(id));

        //Act
        var jobApplication = await unitOfWorkMock.Object.JobApplications.GetByIdAsync(id);
        var actualJson = JsonConvert.SerializeObject(jobApplication);
        var expectedJson = JsonConvert.SerializeObject(expected);

        //Assert
        Assert.Equal(expectedJson, actualJson);
    }

    private Task EditTestJobApplication(JobApplication jobApplication)
    {
        return Task.CompletedTask;
    }

    private async Task<JobApplication> AddTestJobApplicationAsync(JobApplication jobApplication)
    {
        return jobApplication;
    }

    private Task DeleteTestJobApplication(JobApplication jobApplication)
    {
        return Task.CompletedTask;
    }

    private async Task<JobApplication> GetTestJobApplicationByIdAsync(int id)
    {
        if (id == 0) return null;

        return new JobApplication
        {
            Id = 1,
            CVId = 1,
            IsAccepted = true,
            VacancyId = 1,
            UserId = 3
        };
    }

    private async Task<List<JobApplication>> GetTestJobApplicationsAsync()
    {
        var jobApplications = new List<JobApplication>
            {
                new JobApplication
                {
                    Id = 1,
                    CVId = 1,
                    IsAccepted = true,
                    VacancyId = 1,
                    UserId = 3
                },
                new JobApplication
                {
                    Id = 2,
                    CVId = 2,
                    IsAccepted = false,
                    VacancyId = 2,
                    UserId = 3
                }
            };

        return jobApplications;
    }
}