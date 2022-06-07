using AutoMapper;
using Jobs.BLL.Interfaces;
using Jobs.BLL.Models;
using Jobs.DAL.Entities;
using Jobs.DAL.Interfaces;
using Jobs.DAL.Repositories;

namespace Jobs.BLL.Services;

public class CVService : ICVService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly Mapper _cvMapper;

    public CVService()
    {
        _unitOfWork = new UnitOfWork();

        var config = new MapperConfiguration(cfg => cfg.CreateMap<CVModel, CV>().ReverseMap());
        _cvMapper = new Mapper(config);
    }

    public async Task<CVModel> GetCVByIdAsync(int id)
    {
        var cv = await _unitOfWork.CVs.GetByIdAsync(id);
        var cvModel = _cvMapper.Map<CV, CVModel>(cv);
        return cvModel;
    }

    public async Task<List<CVModel>> GetAllCVsAsync()
    {
        var cvs = await _unitOfWork.CVs.GetAllAsync();
        var cvModels = _cvMapper.Map<List<CV>, List<CVModel>>(cvs);

        return cvModels;
    }

    public async Task AddCVAsync(CVModel cvModel)
    {
        var cv = _cvMapper.Map<CVModel, CV>(cvModel);
        await _unitOfWork.CVs.CreateAsync(cv);
    }

    public async Task EditCVAsync(CVModel cvModel)
    {
        var cv = _cvMapper.Map<CVModel, CV>(cvModel);
        await _unitOfWork.CVs.UpdateAsync(cv);
    }

    public async Task DeleteCVAsync(int id)
    {
        var cvsList = await _unitOfWork.CVs.FindAsync(t => t.Id == id);
        var cv = cvsList.First();
        await _unitOfWork.CVs.DeleteAsync(cv);
    }
}