using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;

namespace Jobs.DAL.Entities;

[Index(nameof(Email), IsUnique = true)]
public class User
{
    [Key]
    public int Id { get; set; }

    [Required]
    [Column("Email")]
    public string Email { get; set; }

    [Required]
    [Column("PasswordHash")]
    public string PasswordHash { get; set; }

    [Required]
    [Column("Name")]
    public string Role { get; set; }

    [Required]
    [Column("IsLogged")]
    public bool IsLogged { get; set; }

    public void GeneratePasswordHash(string password)
    {
        using (var sha512 = SHA512.Create())
        {
            var bytes = System.Text.Encoding.UTF8.GetBytes(password);
            byte[] hashCode = sha512.ComputeHash(bytes);
            PasswordHash = BitConverter.ToString(hashCode);
        }
    }
}