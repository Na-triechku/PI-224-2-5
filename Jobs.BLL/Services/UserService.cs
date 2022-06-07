using AutoMapper;
using Jobs.BLL.Interfaces;
using Jobs.BLL.Models;
using Jobs.DAL.Entities;
using Jobs.DAL.Interfaces;
using Jobs.DAL.Repositories;

namespace Jobs.BLL.Services;

public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly Mapper _userMapper;

    public UserService()
    {
        _unitOfWork = new UnitOfWork();

        var config = new MapperConfiguration(cfg => cfg.CreateMap<User, UserModel>().ReverseMap());
        _userMapper = new Mapper(config);
    }

    public async Task<bool> AddUserAsync(UserModel userModel)
    {
        var userList = await _unitOfWork.Users.FindAsync(u => u.Email == userModel.Email);

        if (userList.Count > 0) return false;

        var user = _userMapper.Map<UserModel, User>(userModel);

        await _unitOfWork.Users.CreateAsync(user);

        return true;
    }

    public async Task<bool> LoginAsync(UserModel userModel)
    {
        var userList = await _unitOfWork.Users.FindAsync(u => u.Email == userModel.Email);

        if (userList.Count == 0) return false;

        var user = userList.FirstOrDefault();

        if (user.PasswordHash != userModel.PasswordHash) return false;

        user.IsLogged = true;
        await _unitOfWork.Users.UpdateAsync(user);

        return true;
    }

    public async Task LogoutAsync(UserModel userModel)
    {
        userModel.IsLogged = false;
        var user = _userMapper.Map<UserModel, User>(userModel);
        await _unitOfWork.Users.UpdateAsync(user);
    }

    public async Task DeleteUserAsync(int id)
    {
        var usersList = await _unitOfWork.Users.FindAsync(u => u.Id == id);
        var user = usersList.First();

        await _unitOfWork.Users.DeleteAsync(user);
    }

    public async Task<List<UserModel>> GetUsersAsync()
    {
        var users = await _unitOfWork.Users.GetAllAsync();
        var usersModels = _userMapper.Map<List<User>, List<UserModel>>(users);

        return usersModels;
    }

    public async Task<UserModel?> GetLoggedUserAsync()
    {
        var user = await _unitOfWork.Users.FindAsync(u => u.IsLogged == true);
        if (user.Count > 0)
        {
            var userModel = _userMapper.Map<User, UserModel>(user.First());
            return userModel;
        }
        else
        {
            return null;
        }
    }
}