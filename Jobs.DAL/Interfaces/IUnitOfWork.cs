using Jobs.DAL.Entities;

namespace Jobs.DAL.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IRepository<Vacancy> Vacancies { get; set; }
    IRepository<User> Users { get; set; }
    IRepository<JobApplication> JobApplications { get; set; }
    IRepository<CV> CVs { get; set; }

    Task SaveAsync();
}