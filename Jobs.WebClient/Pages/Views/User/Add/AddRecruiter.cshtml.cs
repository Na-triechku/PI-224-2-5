using Jobs.WebClient.Interfaces;
using Jobs.WebClient.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Jobs.WebClient.Pages.Views.User.Add
{
    public class AddRecruiterModel : PageModel
    {
        private IUserManagerService _userManager;

        public AddRecruiterModel(IUserManagerService userManager)
        {
            _userManager = userManager;
        }

        public void OnGet()
        {
        }

        public async Task OnPostAddManagerAsync(string email, string password, string confirmPassword)
        {
            if (email == null || password == null || confirmPassword == null || password != confirmPassword)
            {
                Response.Redirect("/Views/User/Add/AddManager");
                return;
            }

            var result = await _userManager.AddRecruiterAsync(email, UserManagerService.GeneratePasswordHash(password));

            if (!result)
            {
                Response.Redirect("/Views/User/Add/AddManager");
                return;
            }
            Response.Redirect("/Views/Home/Index", result);
        }
    }
}