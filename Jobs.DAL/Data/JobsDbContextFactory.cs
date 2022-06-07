using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Jobs.DAL.Data;

public class JobsDbContextFactory : IDesignTimeDbContextFactory<JobsDbContext>
{
    public JobsDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<JobsDbContext>();

        ConfigurationBuilder builder = new ConfigurationBuilder();

        builder.SetBasePath(Directory.GetCurrentDirectory());
        builder.AddJsonFile("appsettings.json");

        var config = builder.Build();
        var connectionString = config.GetConnectionString("LocalDbConnection");

        optionsBuilder.UseSqlServer(connectionString);
        return new JobsDbContext(optionsBuilder.Options);
    }
}