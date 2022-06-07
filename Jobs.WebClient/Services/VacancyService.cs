using Jobs.WebClient.Interfaces;
using Jobs.WebClient.Models;
using Serilog;
using System.Net.Http.Headers;

namespace Jobs.WebClient.Services;

public class VacancyService : IVacancyService
{
    public async Task AddVacancyAsync(VacancyViewModel vacancyViewModel)
    {
        try
        {
            if (vacancyViewModel != null)
            {
                using var httpClient = new HttpClient();

                httpClient.BaseAddress = new Uri("http://localhost:60425/");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var result = await httpClient.PostAsJsonAsync("api/addVacancy", vacancyViewModel);
            }
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
        }
    }

    public async Task EditVacancyAsync(VacancyViewModel vacancyViewModel)
    {
        try
        {
            if (vacancyViewModel != null)
            {
                using var httpClient = new HttpClient();

                httpClient.BaseAddress = new Uri("http://localhost:60425/");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var result = await httpClient.PostAsJsonAsync("api/editVacancy", vacancyViewModel);
            }
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
        }
    }

    public async Task DeleteVacancyAsync(int id)
    {
        try
        {
            if (id != null)
            {
                using var httpClient = new HttpClient();

                httpClient.BaseAddress = new Uri("http://localhost:60425/");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var result = await httpClient.PostAsJsonAsync("api/deleteVacancy", id);
            }
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
        }
    }

    public async Task<VacancyViewModel> GetVacancyByIdAsync(int id)
    {
        try
        {
            if (id != null)
            {
                using var httpClient = new HttpClient();

                httpClient.BaseAddress = new Uri("http://localhost:60425/");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var result = await httpClient.GetFromJsonAsync<VacancyViewModel>($"api/getVacancy/?id={id}");

                return result;
            }
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
            return null;
        }
        return null;
    }

    public async Task<List<VacancyViewModel?>> GetAllVacanciesAsync()
    {
        try
        {
            using var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:60425/");
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return await httpClient.GetFromJsonAsync<List<VacancyViewModel>>("api/getVacancies");
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
            return null;
        }
    }
}