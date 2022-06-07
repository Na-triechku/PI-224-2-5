using Jobs.WebClient.Interfaces;
using Jobs.WebClient.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Jobs.WebClient.Pages.Views.User.Authorization
{
    public class RegisterModel : PageModel
    {
        private IUserManagerService _userManager;

        public RegisterModel(IUserManagerService userManager)
        {
            _userManager = userManager;
        }

        public void OnGet()
        {
        }

        public async Task OnPostRegisterAsync(string email, string password, string confirmPassword)
        {
            if (email == null || password == null || confirmPassword == null || password != confirmPassword)
            {
                Response.Redirect("/Views/User/Authorization/Register");
                return;
            }

            var result = await _userManager.RegisterAsync(email, UserManagerService.GeneratePasswordHash(password));

            if (!result)
            {
                Response.Redirect("/Views/User/Authorization/Register");
                return;
            }
            Response.Redirect("/Views/Home/Index", result);
        }
    }
}