using Jobs.WebClient.Interfaces;
using Jobs.WebClient.Models;
using Serilog;
using System.Net.Http.Headers;

namespace Jobs.WebClient.Services;

public class JobApplicationService : IJobApplicationService
{
    public async Task<JobApplicationViewModel> GetJobApplicationByIdAsync(int id)
    {
        try
        {
            if (id != null)
            {
                using var httpClient = new HttpClient();

                httpClient.BaseAddress = new Uri("http://localhost:60425/");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var result = await httpClient.GetFromJsonAsync<JobApplicationViewModel>($"api/getJobApplication/?id={id}");

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

    public async Task<List<JobApplicationViewModel>> GetAllJobApplications()
    {
        try
        {
            using var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:60425/");
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return await httpClient.GetFromJsonAsync<List<JobApplicationViewModel>>("api/getJobApplications");
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
            return null;
        }
    }

    public async Task AddJobApplicationAsync(JobApplicationViewModel jobApplicationViewModel)
    {
        try
        {
            if (jobApplicationViewModel != null)
            {
                using var httpClient = new HttpClient();

                httpClient.BaseAddress = new Uri("http://localhost:60425/");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var result = await httpClient.PostAsJsonAsync("api/addJobApplication", jobApplicationViewModel);
            }
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
        }
    }

    public async Task EditJobApplicationAsync(JobApplicationViewModel jobApplicationViewModel)
    {
        try
        {
            if (jobApplicationViewModel != null)
            {
                using var httpClient = new HttpClient();

                httpClient.BaseAddress = new Uri("http://localhost:60425/");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var result = await httpClient.PostAsJsonAsync("api/editJobApplication", jobApplicationViewModel);
            }
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
        }
    }

    public async Task DeleteJobApplicationAsync(int id)
    {
        try
        {
            if (id != null)
            {
                using var httpClient = new HttpClient();

                httpClient.BaseAddress = new Uri("http://localhost:60425/");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var result = await httpClient.PostAsJsonAsync("api/deleteJobApplication", id);
            }
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
        }
    }
}