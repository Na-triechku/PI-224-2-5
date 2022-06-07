using Jobs.DAL.Entities;
using System.Collections;

namespace Jobs.Tests.ServicesTests.TestsData;

public class AddJobApplicationTestsData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
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
                Id = 1,
                CVId = 1,
                IsAccepted = true,
                VacancyId = 1,
                UserId = 3
            }
        };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public class EditJobApplicationTestsData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        {
            new JobApplication
            {
                Id = 1,
                CVId = 1,
                IsAccepted = true,
                VacancyId = 1,
                UserId = 3
            },
            Task.CompletedTask
        };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public class DeleteJobApplicationTestsData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        {
            new JobApplication
            {
                Id = 1,
                CVId = 1,
                IsAccepted = true,
                VacancyId = 1,
                UserId = 3
            },
            Task.CompletedTask
        };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public class GetJobApplicationByIdTestsData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        { 1, new JobApplication
            {
                Id = 1,
                CVId = 1,
                IsAccepted = true,
                VacancyId = 1,
                UserId = 3
            }
        };
        yield return new object[] { 0, null };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}