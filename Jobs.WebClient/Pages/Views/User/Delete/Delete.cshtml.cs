using Jobs.WebClient.Interfaces;
using Jobs.WebClient.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;

namespace Jobs.WebClient.Pages.Views.User.Delete
{
    public class DeleteModel : PageModel
    {
        private IUserManagerService _userManager;
        public List<UserViewModel> Users { get; set; }

        public DeleteModel(IUserManagerService userManager)
        {
            _userManager = userManager;

            using var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:60425/");
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            Users = httpClient.GetFromJsonAsync<List<UserViewModel>>("api/getUsers").Result!;
        }

        public void OnGet()
        {
        }

        public async Task OnPostDeleteAsync(int id)
        {
            await _userManager.DeleteUserAsync(id);
            Response.Redirect("/Views/User/Delete/Delete");
        }
    }
}