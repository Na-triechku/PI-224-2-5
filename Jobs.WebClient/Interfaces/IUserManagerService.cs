using Jobs.WebClient.Models;

namespace Jobs.WebClient.Interfaces;

public interface IUserManagerService
{
    UserViewModel? LoggedUser { get; }

    Task<bool> LoginAsync(string email, string passwordHash);

    Task<bool> RegisterAsync(string email, string passwordHash);

    Task<bool> AddAdministratorAsync(string email, string passwordHash);

    Task<bool> AddRecruiterAsync(string email, string passwordHash);

    Task<bool> AddUserAsync(string email, string passwordHash);

    Task<bool> DeleteUserAsync(int id);

    Task LogoutAsync();
}