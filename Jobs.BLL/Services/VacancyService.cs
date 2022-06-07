using AutoMapper;
using Jobs.BLL.Interfaces;
using Jobs.BLL.Models;
using Jobs.DAL.Entities;
using Jobs.DAL.Interfaces;
using Jobs.DAL.Repositories;

namespace Jobs.BLL.Services;

public class VacancyService : IVacancyService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly Mapper _vacancyMapper;

    public VacancyService()
    {
        _unitOfWork = new UnitOfWork();

        var config = new MapperConfiguration(cfg => cfg.CreateMap<Vacancy, VacancyModel>().ReverseMap());
        _vacancyMapper = new Mapper(config);
    }

    public async Task<VacancyModel> GetVacancyByIdAsync(int id)
    {
        var vacancy = await _unitOfWork.Vacancies.GetByIdAsync(id);
        var vacancyModel = _vacancyMapper.Map<Vacancy, VacancyModel>(vacancy);
        return vacancyModel;
    }

    public async Task<List<VacancyModel>> GetAllVacanciesAsync()
    {
        var vacancies = await _unitOfWork.Vacancies.GetAllAsync();
        var vacancyModels = _vacancyMapper.Map<List<Vacancy>, List<VacancyModel>>(vacancies);

        return vacancyModels;
    }

    public async Task AddVacancyAsync(VacancyModel vacancyModel)
    {
        var vacancy = _vacancyMapper.Map<VacancyModel, Vacancy>(vacancyModel);
        await _unitOfWork.Vacancies.CreateAsync(vacancy);
    }

    public async Task EditVacancyAsync(VacancyModel vacancyModel)
    {
        var vacancy = _vacancyMapper.Map<VacancyModel, Vacancy>(vacancyModel);
        await _unitOfWork.Vacancies.UpdateAsync(vacancy);
    }

    public async Task DeleteVacancyAsync(int id)
    {
        var vacancyList = await _unitOfWork.Vacancies.FindAsync(t => t.Id == id);
        var vacancy = vacancyList.First();
        await _unitOfWork.Vacancies.DeleteAsync(vacancy);
    }
}