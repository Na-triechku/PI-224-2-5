using Jobs.BLL.Models;

namespace Jobs.BLL.Interfaces;

public interface IUserService
{
    Task<bool> AddUserAsync(UserModel userModel);

    Task<bool> LoginAsync(UserModel userModel);

    Task LogoutAsync(UserModel userModel);

    Task DeleteUserAsync(int id);

    Task<List<UserModel>> GetUsersAsync();

    Task<UserModel?> GetLoggedUserAsync();
}