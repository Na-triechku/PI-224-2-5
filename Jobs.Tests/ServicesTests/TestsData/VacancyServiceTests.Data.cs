using Jobs.DAL.Entities;
using System.Collections;

namespace Jobs.Tests.ServicesTests.TestsData;

public class AddVacancyTestsData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
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
                Id = 1,
                Name = ".Net Traineeship",
                Position = "Trainee software engineer",
                StartDate = new DateTime(2022, 5, 30),
                RequiredSkills = ".Net, C#, OOP, SQL",
                RequiredExperience = 0,
                Salary = 400
            }
        };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public class EditVacancyTestsData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
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
            Task.CompletedTask
        };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public class DeleteVacancyTestsData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
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
            Task.CompletedTask
        };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public class GetVacancyByIdTestsData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        { 1, new Vacancy
            {
                Id = 1,
                Name = ".Net Traineeship",
                Position = "Trainee software engineer",
                StartDate = new DateTime(2022, 5, 30),
                RequiredSkills = ".Net, C#, OOP, SQL",
                RequiredExperience = 0,
                Salary = 400
            }
        };
        yield return new object[] { 0, null };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}