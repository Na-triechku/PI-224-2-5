using Jobs.WebClient.Interfaces;
using Jobs.WebClient.Models;
using Serilog;
using System.Net.Http.Headers;

namespace Jobs.WebClient.Services;

public class CVService : ICVService
{
    public async Task<List<CVViewModel>> GetAllCVs()
    {
        try
        {
            using var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:60425/");
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return await httpClient.GetFromJsonAsync<List<CVViewModel>>("api/getCVs");
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
            return null;
        }
    }

    public async Task AddCVAsync(CVViewModel cvViewModel)
    {
        try
        {
            if (cvViewModel != null)
            {
                using var httpClient = new HttpClient();

                httpClient.BaseAddress = new Uri("http://localhost:60425/");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var result = await httpClient.PostAsJsonAsync("api/addCV", cvViewModel);
            }
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
        }
    }

    public async Task<CVViewModel> GetCVByIdAsync(int id)
    {
        try
        {
            if (id != null)
            {
                using var httpClient = new HttpClient();

                httpClient.BaseAddress = new Uri("http://localhost:60425/");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var result = await httpClient.GetFromJsonAsync<CVViewModel>($"api/getCV/?id={id}");

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

    public async Task EditCVAsync(CVViewModel cvViewModel)
    {
        try
        {
            if (cvViewModel != null)
            {
                using var httpClient = new HttpClient();

                httpClient.BaseAddress = new Uri("http://localhost:60425/");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var result = await httpClient.PostAsJsonAsync("api/editCV", cvViewModel);
            }
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
        }
    }

    public async Task DeleteCVAsync(int id)
    {
        try
        {
            if (id != null)
            {
                using var httpClient = new HttpClient();

                httpClient.BaseAddress = new Uri("http://localhost:60425/");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var result = await httpClient.PostAsJsonAsync("api/deleteCV", id);
            }
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
        }
    }
}