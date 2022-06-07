namespace Jobs.BLL.Models;

public class VacancyModel
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Position { get; set; }

    public int RequiredExperience { get; set; }

    public string RequiredSkills { get; set; }

    public DateTime StartDate { get; set; }

    public double Salary { get; set; }
}