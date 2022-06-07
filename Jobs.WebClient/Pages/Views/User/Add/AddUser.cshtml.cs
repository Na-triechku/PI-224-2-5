using Jobs.WebClient.Interfaces;
using Jobs.WebClient.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Jobs.WebClient.Pages.Views.User.Add
{
    public class AddUserModel : PageModel
    {
        private IUserManagerService _userManager;

        public AddUserModel(IUserManagerService userManager)
        {
            _userManager = userManager;
        }

        public void OnGet()
        {
        }

        public async Task OnPostAddUserAsync(string email, string password, string confirmPassword)
        {
            if (email == null || password == null || confirmPassword == null || password != confirmPassword)
            {
                Response.Redirect("/Views/User/Add/AddUser");
                return;
            }

            var result = await _userManager.AddUserAsync(email, UserManagerService.GeneratePasswordHash(password));

            if (!result)
            {
                Response.Redirect("/Views/User/Add/AddUser");
                return;
            }
            Response.Redirect("/Views/Home/Index", result);
        }
    }
}