using Jobs.BLL.Interfaces;
using Jobs.BLL.Services;
using Serilog;
using Serilog.Sinks.SystemConsole.Themes;

namespace Jobs.PL;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();

        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddScoped<IVacancyService, VacancyService>();
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddTransient<ICVService, CVService>();
        builder.Services.AddTransient<IJobApplicationService, JobApplicationService>();

        var app = builder.Build();

        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Console(theme: AnsiConsoleTheme.Code)
            .WriteTo.File(AppContext.BaseDirectory + $"/logs/{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}_log.log", rollingInterval: RollingInterval.Day)
            .CreateLogger();

#if DEBUG
        app.UseDeveloperExceptionPage();
        app.UseHsts();
#endif

        app.UseHttpsRedirection();
        app.MapControllers();
        app.Run();
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}