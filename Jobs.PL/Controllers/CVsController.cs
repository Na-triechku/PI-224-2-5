using Jobs.BLL.Interfaces;
using Jobs.BLL.Models;
using Microsoft.AspNetCore.Mvc;

namespace Jobs.PL.Controllers
{
    public class CVsController : Controller
    {
        private readonly ICVService _cvService;

        public CVsController(ICVService cvService)
        {
            _cvService = cvService;
        }

        [HttpGet]
        [Route("api/getCVs")]
        public async Task<List<CVModel>> GetAllCVsAsync()
        {
            return await _cvService.GetAllCVsAsync();
        }

        [HttpGet]
        [Route("api/getCV")]
        public async Task<CVModel> GetCVAsync(int id)
        {
            return await _cvService.GetCVByIdAsync(id);
        }

        [HttpPost]
        [Route("api/addCV")]
        public async Task AddCVAsync([FromBody] CVModel cvModel)
        {
            if (cvModel == null) return;
            await _cvService.AddCVAsync(cvModel);
        }

        [HttpPost]
        [Route("api/deleteCV")]
        public async Task DeleteCVAsync([FromBody] int id)
        {
            if (id == null) return;
            await _cvService.DeleteCVAsync(id);
        }

        [HttpPost]
        [Route("api/editCV")]
        public async Task EditCVAsync([FromBody] CVModel cvModel)
        {
            if (cvModel == null) return;
            await _cvService.EditCVAsync(cvModel);
        }
    }
}