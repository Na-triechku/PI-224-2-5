using Jobs.BLL.Interfaces;
using Jobs.BLL.Models;
using Microsoft.AspNetCore.Mvc;

namespace Jobs.PL.Controllers;

public class UsersController : Controller
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    [Route("api/getLoggedUser")]
    public async Task<UserModel?> GetLoggedUserAsync()
    {
        return await _userService.GetLoggedUserAsync();
    }

    [HttpGet]
    [Route("api/getUsers")]
    public async Task<List<UserModel>> GetUsersAsync()
    {
        return await _userService.GetUsersAsync();
    }

    [HttpPost]
    [Route("api/addUser")]
    public async Task<IActionResult> AddUserAsync([FromBody] UserModel userModel)
    {
        if (userModel == null) return BadRequest();

        var result = await _userService.AddUserAsync(userModel);

        if (result)
        {
            return Ok();
        }
        else
        {
            return BadRequest();
        }
    }

    [HttpPost]
    [Route("api/login")]
    public async Task<IActionResult> LoginAsync([FromBody] UserModel userModel)
    {
        if (userModel == null) return BadRequest();

        var result = await _userService.LoginAsync(userModel);

        if (result)
        {
            return Ok();
        }
        else
        {
            return BadRequest();
        }
    }

    [HttpPost]
    [Route("api/logout")]
    public async Task LogoutAsync([FromBody] UserModel userModel)
    {
        if (userModel == null) return;

        await _userService.LogoutAsync(userModel);
    }

    [HttpPost]
    [Route("api/deleteUser")]
    public async Task DeleteUserAsync([FromBody] int id)
    {
        await _userService.DeleteUserAsync(id);
    }
}