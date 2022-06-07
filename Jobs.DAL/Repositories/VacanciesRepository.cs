using Jobs.DAL.Data;
using Jobs.DAL.Entities;
using Jobs.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Jobs.DAL.Repositories;

public class VacanciesRepository : IRepository<Vacancy>
{
    private readonly JobsDbContext _context;

    public VacanciesRepository(JobsDbContext context)
    {
        _context = context;
    }

    public async Task<List<Vacancy>> GetAllAsync()
    {
        try
        {
            var obj = await _context.Vacancies.ToListAsync();
            if (obj != null) return obj;
            else return null;
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
            return null;
        }
    }

    public async Task<Vacancy> GetByIdAsync(int id)
    {
        try
        {
            if (id != null)
            {
                var Obj = await _context.Vacancies.Where(u => u.Id == id).FirstOrDefaultAsync();
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

    public async Task<List<Vacancy>> FindAsync(Func<Vacancy, bool> predicate)
    {
        try
        {
            if (predicate != null)
            {
                return _context.Vacancies.Where(predicate).ToList();
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

    public async Task<Vacancy> CreateAsync(Vacancy tour)
    {
        try
        {
            if (tour != null)
            {
                var obj = await _context.Vacancies.AddAsync(tour);
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

    public async Task UpdateAsync(Vacancy vacancy)
    {
        try
        {
            if (vacancy != null)
            {
                var obj = _context.Vacancies.Update(vacancy);
                if (obj != null) await _context.SaveChangesAsync();
            }
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
        }
    }

    public async Task DeleteAsync(Vacancy vacancy)
    {
        try
        {
            if (vacancy != null)
            {
                var obj = _context.Vacancies.Remove(vacancy);
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