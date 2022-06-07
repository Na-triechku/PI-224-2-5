using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jobs.DAL.Entities;

public class Vacancy
{
    [Key]
    public int Id { get; set; }

    [Required]
    [Column("Name")]
    public string Name { get; set; }

    [Required]
    [Column("Position")]
    public string Position { get; set; }

    [Required]
    [Column("RequiredExperience")]
    public int RequiredExperience { get; set; }

    [Required]
    [Column("RequiredSkills")]
    public string RequiredSkills { get; set; }

    [Required]
    [Column("StartDate")]
    public DateTime StartDate { get; set; }

    [Required]
    [Column("Salary")]
    public double Salary { get; set; }
}