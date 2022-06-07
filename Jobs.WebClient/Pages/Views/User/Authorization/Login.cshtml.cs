using Jobs.WebClient.Interfaces;
using Jobs.WebClient.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Serilog;

namespace Jobs.WebClient.Pages.Views.User.Authorization
{
    public class LoginModel : PageModel
    {
        private IUserManagerService _userManager;

        public LoginModel(IUserManagerService userManager)
        {
            _userManager = userManager;
        }

        public void OnGet()
        {
        }

        public async Task OnPostLoginAsync(string email, string password)
        {
            if (email == null || password == null)
            {
                Response.Redirect("/Views/User/Authorization/Login");
                return;
            }

            var result = await _userManager.LoginAsync(email, UserManagerService.GeneratePasswordHash(password));

            if (!result)
            {
                Response.Redirect("/Views/User/Authorization/Login");
                return;
            }

            Response.Redirect("/Views/Home/Index");
        }
    }
}