using Jobs.DAL.Entities;
using Jobs.DAL.Interfaces;
using Jobs.Tests.ServicesTests.TestsData;
using Moq;
using Newtonsoft.Json;

namespace Jobs.Tests.ServicesTests.Tests;

public class VacancyServiceTests
{
    [Fact]
    public void GetAllVacanciesAsyncReturnVacanciesList()
    {
        //Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        unitOfWorkMock.Setup(unitOfWork => unitOfWork.Vacancies.GetAllAsync()).Returns(GetTestVacanciesAsync());

        //Act
        var vacancies = unitOfWorkMock.Object.Vacancies.GetAllAsync().Result;

        //Assert
        Assert.NotNull(vacancies);
        Assert.IsType<List<Vacancy>>(vacancies);
    }

    [Theory]
    [ClassData(typeof(EditVacancyTestsData))]
    public async Task EditVacancyAsync(Vacancy vacancy, Task expected)
    {
        //Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        unitOfWorkMock.Setup(unitOfWork => unitOfWork.Vacancies.UpdateAsync(vacancy)).Returns(EditTestVacancy(vacancy));

        //Act
        var actual = unitOfWorkMock.Object.Vacancies.UpdateAsync(vacancy);

        //Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [ClassData(typeof(AddVacancyTestsData))]
    public async Task AddVacancyAsync(Vacancy vacancy, Vacancy expected)
    {
        //Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        unitOfWorkMock.Setup(unitOfWork => unitOfWork.Vacancies.CreateAsync(vacancy)).Returns(AddTestVacancyAsync(vacancy));

        //Act
        var actual = await unitOfWorkMock.Object.Vacancies.CreateAsync(vacancy);
        var actualJson = JsonConvert.SerializeObject(actual);
        var expectedJson = JsonConvert.SerializeObject(expected);

        //Assert
        Assert.Equal(expectedJson, actualJson);
    }

    [Theory]
    [ClassData(typeof(DeleteVacancyTestsData))]
    public async Task DeleteVacancyAsync(Vacancy vacancy, Task expected)
    {
        //Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        unitOfWorkMock.Setup(unitOfWork => unitOfWork.Vacancies.DeleteAsync(vacancy)).Returns(DeleteTestVacancy(vacancy));

        //Act
        var actual = unitOfWorkMock.Object.Vacancies.DeleteAsync(vacancy);

        //Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [ClassData(typeof(GetVacancyByIdTestsData))]
    public async Task GetVacancyByIdAsyncReturnVacancy(int id, Vacancy expected)
    {
        //Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        unitOfWorkMock.Setup(unitOfWork => unitOfWork.Vacancies.GetByIdAsync(id)).Returns(GetTestVacancyByIdAsync(id));

        //Act
        var vacancy = await unitOfWorkMock.Object.Vacancies.GetByIdAsync(id);
        var actualJson = JsonConvert.SerializeObject(vacancy);
        var expectedJson = JsonConvert.SerializeObject(expected);

        //Assert
        Assert.Equal(expectedJson, actualJson);
    }

    private Task EditTestVacancy(Vacancy vacancy)
    {
        return Task.CompletedTask;
    }

    private async Task<Vacancy> AddTestVacancyAsync(Vacancy vacancy)
    {
        return vacancy;
    }

    private Task DeleteTestVacancy(Vacancy tour)
    {
        return Task.CompletedTask;
    }

    private async Task<Vacancy> GetTestVacancyByIdAsync(int id)
    {
        if (id == 0) return null;

        return new Vacancy
        {
            Id = 1,
            Name = ".Net Traineeship",
            Position = "Trainee software engineer",
            StartDate = new DateTime(2022, 5, 30),
            RequiredSkills = ".Net, C#, OOP, SQL",
            RequiredExperience = 0,
            Salary = 400
        };
    }

    private async Task<List<Vacancy>> GetTestVacanciesAsync()
    {
        var vacancies = new List<Vacancy>
            {
                new Vacancy
                {
                    Id = 1,
                    Name = ".Net Traineeship",
                    Position = "Trainee software engineer",
                    StartDate = new DateTime(2022, 5, 30),
                    RequiredSkills = ".Net, C#, OOP, SQL",
                    RequiredExperience = 0,
                    Salary = 400
                },
                new Vacancy
                {
                    Id = 2,
                    Name = ".Net Junior",
                    Position = "Junior software engineer",
                    StartDate = new DateTime(2022, 6, 10),
                    RequiredSkills = ".Net, C#, OOP, SQL, ASP.NET, .Net Core, React",
                    RequiredExperience = 1,
                    Salary = 800
                }
            };

        return vacancies;
    }
}