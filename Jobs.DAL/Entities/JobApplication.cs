using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jobs.DAL.Entities;

public class JobApplication
{
    [Key]
    public int Id { get; set; }

    [Required]
    [Column("VacancyId")]
    public int VacancyId { get; set; }

    [Required]
    [Column("UserId")]
    public int UserId { get; set; }

    [Required]
    [Column("CVId")]
    public int CVId { get; set; }

    [Required]
    [Column("IsAccepted")]
    public bool IsAccepted { get; set; }
}