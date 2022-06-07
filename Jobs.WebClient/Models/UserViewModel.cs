namespace Jobs.WebClient.Models;

public class UserViewModel
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string Role { get; set; }
    public bool IsLogged { get; set; }
}