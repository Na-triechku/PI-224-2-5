using Jobs.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Sinks.SystemConsole.Themes;

namespace Jobs.DAL.Data;

public class JobsDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public DbSet<Vacancy> Vacancies { get; set; }

    public DbSet<JobApplication> JobApplications { get; set; }

    public DbSet<CV> CVs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var builder = new ConfigurationBuilder();

            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");

            var config = builder.Build();
            var connectionString = config.GetConnectionString("LocalDbConnection");

            optionsBuilder.UseSqlServer(connectionString);
        }

        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Console(theme: AnsiConsoleTheme.Code)
            .WriteTo.File(AppContext.BaseDirectory + $"/logs/{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}_log.log", rollingInterval: RollingInterval.Day)
            .CreateLogger();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        SeedData.SeedUsers(modelBuilder);
        SeedData.SeedVacancies(modelBuilder);
    }

    public JobsDbContext()
    {
        try
        {
            Database.Migrate();
        }
        catch
        {
            Log.Information("Migration, try #1");
            try
            {
                Database.Migrate();
            }
            catch
            {
                Log.Information("Migration, try #2");
                try
                {
                    Database.Migrate();
                }
                catch
                {
                    Log.Information("Migration, try #3");
                    Log.Information("Migration failed.");
                }
            }
        }
    }

    public JobsDbContext(DbContextOptions options) : base(options)
    {
        try
        {
            Database.Migrate();
        }
        catch
        {
            Log.Information("Migration, try #1");
            try
            {
                Database.Migrate();
            }
            catch
            {
                Log.Information("Migration, try #2");
                try
                {
                    Database.Migrate();
                }
                catch
                {
                    Log.Information("Migration, try #3");
                    Log.Information("Migration failed.");
                }
            }
        }
    }
}