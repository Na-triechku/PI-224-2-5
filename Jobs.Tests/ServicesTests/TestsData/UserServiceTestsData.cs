using Jobs.DAL.Entities;
using System.Collections;

namespace Jobs.Tests.ServicesTests.TestsData;

public class AddUserTestsData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        {
            new User
            {
                Id = 3,
                Email = "user@mail.com",
                IsLogged = false,
                Role = "User"
            },
            new User
            {
                Id = 3,
                Email = "user@mail.com",
                IsLogged = false,
                Role = "User"
            }
        };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public class EditUserTestsData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        {
            new User
            {
                Id = 3,
                Email = "user@mail.com",
                IsLogged = false,
                Role = "User"
            },
            Task.CompletedTask
        };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public class LoginUserTestsData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        {
            new User
            {
                Id = 3,
                Email = "user@mail.com",
                IsLogged = false,
                Role = "User"
            },
            Task.CompletedTask
        };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public class LogoutUserTestsData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        {
            new User
            {
                Id = 3,
                Email = "user@mail.com",
                IsLogged = false,
                Role = "User"
            },
            Task.CompletedTask
        };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public class DeleteUserTestsData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        {
            new User
            {
                Id = 3,
                Email = "user@mail.com",
                IsLogged = false,
                Role = "User"
            },
            Task.CompletedTask
        };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public class GetUserByIdTestsData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        { 1, new User
            {
                Id = 3,
                Email = "user@mail.com",
                IsLogged = false,
                Role = "User"
            }
        };
        yield return new object[] { 0, null };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}