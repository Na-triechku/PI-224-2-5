using Jobs.DAL.Data;
using Jobs.DAL.Entities;
using Jobs.DAL.Interfaces;

namespace Jobs.DAL.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private bool _disposed = false;
    private readonly JobsDbContext _context;

    private IRepository<Vacancy> _vacancies;
    private IRepository<User> _users;
    private IRepository<JobApplication> _jobApplications;
    private IRepository<CV> _cvs;

    public UnitOfWork()
    {
        _context = new JobsDbContext();
    }

    public IRepository<Vacancy> Vacancies
    {
        get
        {
            return _vacancies ??= new VacanciesRepository(_context);
        }

        set => _vacancies = value;
    }

    public IRepository<User> Users
    {
        get
        {
            return _users ??= new UsersRepository(_context);
        }

        set => _users = value;
    }

    public IRepository<JobApplication> JobApplications
    {
        get
        {
            return _jobApplications ??= new JobApplicationsRepository(_context);
        }

        set => _jobApplications = value;
    }

    public IRepository<CV> CVs
    {
        get
        {
            return _cvs ??= new CVsRepository(_context);
        }

        set => _cvs = value;
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }

    public virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            _disposed = true;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}