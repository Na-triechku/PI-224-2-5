using Jobs.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Jobs.DAL.Data;

public static class SeedData
{
    public static void SeedUsers(ModelBuilder modelBuilder)
    {
        User admin = new User
        {
            Id = 1,
            Email = "administrator@email.ua",
            IsLogged = true,
            Role = "Administrator"
        };
        User recruiter = new User
        {
            Id = 2,
            Email = "recruiter@email.ua",
            IsLogged = false,
            Role = "Recruiter"
        };
        User user = new User
        {
            Id = 3,
            Email = "user@email.ua",
            IsLogged = false,
            Role = "User"
        };

        admin.GeneratePasswordHash("administrator");
        recruiter.GeneratePasswordHash("recruiter");
        user.GeneratePasswordHash("user");

        modelBuilder.Entity<User>().HasData(admin, recruiter, user);
    }

    public static void SeedVacancies(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Vacancy>().HasData(
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
        );
    }
}