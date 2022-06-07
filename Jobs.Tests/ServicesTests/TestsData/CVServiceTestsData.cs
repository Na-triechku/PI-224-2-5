using Jobs.DAL.Entities;
using System.Collections;

namespace Jobs.Tests.ServicesTests.TestsData;

public class AddCVTestsData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        {
            new CV
            {
                Id = 3,
                Name = ".Net Traineeship",
                Position = "Trainee software engineer",
                ExpectedSalary = 400,
                Experience = 0,
                Skills = ".Net, C#, OOP, SQL"
            },
            new CV
            {
                Id = 3,
                Name = ".Net Traineeship",
                Position = "Trainee software engineer",
                ExpectedSalary = 400,
                Experience = 0,
                Skills = ".Net, C#, OOP, SQL"
            }
        };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public class EditCVTestsData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        {
            new CV
            {
                Id = 3,
                Name = ".Net Traineeship",
                Position = "Trainee software engineer",
                ExpectedSalary = 400,
                Experience = 0,
                Skills = ".Net, C#, OOP, SQL"
            },
            Task.CompletedTask
        };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public class DeleteCVTestsData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        {
            new CV
            {
                Id = 3,
                Name = ".Net Traineeship",
                Position = "Trainee software engineer",
                ExpectedSalary = 400,
                Experience = 0,
                Skills = ".Net, C#, OOP, SQL"
            },
            Task.CompletedTask
        };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public class GetCVByIdTestsData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        { 1, new CV
            {
                Id = 3,
                Name = ".Net Traineeship",
                Position = "Trainee software engineer",
                ExpectedSalary = 400,
                Experience = 0,
                Skills = ".Net, C#, OOP, SQL"
            }
        };
        yield return new object[] { 0, null };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}