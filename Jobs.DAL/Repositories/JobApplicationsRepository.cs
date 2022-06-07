using Jobs.DAL.Data;
using Jobs.DAL.Entities;
using Jobs.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Jobs.DAL.Repositories;

public class JobApplicationsRepository : IRepository<JobApplication>
{
    private readonly JobsDbContext _context;

    public JobApplicationsRepository(JobsDbContext context)
    {
        _context = context;
    }

    public async Task<List<JobApplication>> GetAllAsync()
    {
        try
        {
            var obj = await _context.JobApplications.ToListAsync();
            if (obj != null) return obj;
            else return null;
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
            return null;
        }
    }

    public async Task<JobApplication> GetByIdAsync(int id)
    {
        try
        {
            if (id != null)
            {
                var Obj = await _context.JobApplications.Where(u => u.Id == id).FirstOrDefaultAsync();
                if (Obj != null) return Obj;
                else return null;
            }
            else
            {
                return null;
            }
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
            return null;
        }
    }

    public async Task<List<JobApplication>> FindAsync(Func<JobApplication, bool> predicate)
    {
        try
        {
            if (predicate != null)
            {
                return _context.JobApplications.Where(predicate).ToList();
            }
            else
            {
                return null;
            }
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
            return null;
        }
    }

    public async Task<JobApplication> CreateAsync(JobApplication jobApplication)
    {
        try
        {
            if (jobApplication != null)
            {
                var obj = await _context.JobApplications.AddAsync(jobApplication);
                await _context.SaveChangesAsync();
                return obj.Entity;
            }
            else
            {
                return null;
            }
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
            return null;
        }
    }

    public async Task UpdateAsync(JobApplication jobApplication)
    {
        try
        {
            if (jobApplication != null)
            {
                var obj = _context.JobApplications.Update(jobApplication);
                if (obj != null) await _context.SaveChangesAsync();
            }
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
        }
    }

    public async Task DeleteAsync(JobApplication jobApplication)
    {
        try
        {
            if (jobApplication != null)
            {
                var obj = _context.JobApplications.Remove(jobApplication);
                if (obj != null)
                {
                    await _context.SaveChangesAsync();
                }
            }
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
        }
    }
}