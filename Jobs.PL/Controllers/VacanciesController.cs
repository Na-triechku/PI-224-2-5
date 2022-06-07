using Jobs.BLL.Interfaces;
using Jobs.BLL.Models;
using Microsoft.AspNetCore.Mvc;

namespace Jobs.PL.Controllers
{
    public class VacanciesController : Controller
    {
        private readonly IVacancyService _vacancyService;

        public VacanciesController(IVacancyService vacancyService)
        {
            _vacancyService = vacancyService;
        }

        [HttpGet]
        [Route("")]
        [Route("api/getVacancies")]
        public async Task<List<VacancyModel>> GetAllVacanciesAsync()
        {
            return await _vacancyService.GetAllVacanciesAsync();
        }

        [HttpGet]
        [Route("api/getVacancy")]
        public async Task<VacancyModel> GetVacancyAsync(int id)
        {
            return await _vacancyService.GetVacancyByIdAsync(id);
        }

        [HttpPost]
        [Route("api/addVacancy")]
        public async Task AddVacancyAsync([FromBody] VacancyModel vacancyModel)
        {
            if (vacancyModel == null) return;
            await _vacancyService.AddVacancyAsync(vacancyModel);
        }

        [HttpPost]
        [Route("api/deleteVacancy")]
        public async Task DeleteVacancyAsync([FromBody] int id)
        {
            if (id == null) return;
            await _vacancyService.DeleteVacancyAsync(id);
        }

        [HttpPost]
        [Route("api/editVacancy")]
        public async Task EditVacancyAsync([FromBody] VacancyModel vacancyModel)
        {
            if (vacancyModel == null) return;
            await _vacancyService.EditVacancyAsync(vacancyModel);
        }
    }
}