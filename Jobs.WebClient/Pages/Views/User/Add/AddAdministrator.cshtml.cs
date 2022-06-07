using Jobs.WebClient.Interfaces;
using Jobs.WebClient.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Jobs.WebClient.Pages.Views.User.Add
{
    public class AddAdministratorModel : PageModel
    {
        private IUserManagerService _userManager;

        public AddAdministratorModel(IUserManagerService userManager)
        {
            _userManager = userManager;
        }

        public void OnGet()
        {
        }

        public async Task OnPostAddAdministratorAsync(string email, string password, string confirmPassword)
        {
            if (email == null || password == null || confirmPassword == null || password != confirmPassword)
            {
                Response.Redirect("/Views/User/Add/AddAdministrator");
                return;
            }

            var result = await _userManager.AddAdministratorAsync(email, UserManagerService.GeneratePasswordHash(password));

            if (!result)
            {
                Response.Redirect("/Views/User/Add/AddAdministrator");
                return;
            }
            Response.Redirect("/Views/Home/Index", result);
        }
    }
}