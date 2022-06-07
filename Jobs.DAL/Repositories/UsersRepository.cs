using Jobs.DAL.Data;
using Jobs.DAL.Entities;
using Jobs.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Jobs.DAL.Repositories;

public class UsersRepository : IRepository<User>
{
    private readonly JobsDbContext _context;

    public UsersRepository(JobsDbContext context)
    {
        _context = context;
    }

    public async Task<List<User>> GetAllAsync()
    {
        try
        {
            var obj = await _context.Users.ToListAsync();
            if (obj != null) return obj;
            else return null;
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
            return null;
        }
    }

    public async Task<User> GetByIdAsync(int id)
    {
        try
        {
            if (id != null)
            {
                var Obj = await _context.Users.Where(u => u.Id == id).FirstOrDefaultAsync();
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

    public async Task<List<User>> FindAsync(Func<User, bool> predicate)
    {
        try
        {
            if (predicate != null)
            {
                return _context.Users.Where(predicate).ToList();
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

    public async Task<User> CreateAsync(User user)
    {
        try
        {
            if (user != null)
            {
                var obj = await _context.Users.AddAsync(user);
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

    public async Task UpdateAsync(User user)
    {
        try
        {
            if (user != null)
            {
                var obj = _context.Users.Update(user);
                if (obj != null) await _context.SaveChangesAsync();
            }
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
        }
    }

    public async Task DeleteAsync(User user)
    {
        try
        {
            if (user != null)
            {
                var obj = _context.Users.Remove(user);
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