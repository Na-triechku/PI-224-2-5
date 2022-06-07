using Jobs.DAL.Data;
using Jobs.DAL.Entities;
using Jobs.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Jobs.DAL.Repositories;

public class CVsRepository : IRepository<CV>
{
    private readonly JobsDbContext _context;

    public CVsRepository(JobsDbContext context)
    {
        _context = context;
    }

    public async Task<List<CV>> GetAllAsync()
    {
        try
        {
            var obj = await _context.CVs.ToListAsync();
            if (obj != null) return obj;
            else return null;
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
            return null;
        }
    }

    public async Task<CV> GetByIdAsync(int id)
    {
        try
        {
            if (id != null)
            {
                var Obj = await _context.CVs.Where(u => u.Id == id).FirstOrDefaultAsync();
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

    public async Task<List<CV>> FindAsync(Func<CV, bool> predicate)
    {
        try
        {
            if (predicate != null)
            {
                return _context.CVs.Where(predicate).ToList();
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

    public async Task<CV> CreateAsync(CV cv)
    {
        try
        {
            if (cv != null)
            {
                var obj = await _context.CVs.AddAsync(cv);
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

    public async Task UpdateAsync(CV cv)
    {
        try
        {
            if (cv != null)
            {
                var obj = _context.CVs.Update(cv);
                if (obj != null) await _context.SaveChangesAsync();
            }
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
        }
    }

    public async Task DeleteAsync(CV cv)
    {
        try
        {
            if (cv != null)
            {
                var obj = _context.CVs.Remove(cv);
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