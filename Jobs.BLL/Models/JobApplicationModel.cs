namespace Jobs.BLL.Models;

public class JobApplicationModel
{
    public int Id { get; set; }

    public int VacancyId { get; set; }

    public int UserId { get; set; }

    public int CVId { get; set; }

    public bool IsAccepted { get; set; }
}