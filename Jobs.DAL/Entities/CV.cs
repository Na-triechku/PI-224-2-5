using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jobs.DAL.Entities;

public class CV
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
    [Column("Experience")]
    public int Experience { get; set; }

    [Required]
    [Column("Skills")]
    public string Skills { get; set; }

    [Required]
    [Column("ExpectedSalary")]
    public double ExpectedSalary { get; set; }
}