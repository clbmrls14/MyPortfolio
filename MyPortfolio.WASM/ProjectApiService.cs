using MyPortfolio.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyPortfolio.WASM
{
    public class ProjectApiService
    {
        private readonly HttpClient client;

        public ProjectApiService(HttpClient client)
        {
            this.client = client;
        }

        public async Task<IEnumerable<Project>> GetProjectsAsync()
        {
            var response = await client.GetAsync("api/project");
            return await client.GetFromJsonAsync<IEnumerable<Project>>("api/project");
        }

        public async Task<Project> GetProjectByIdAsync(int id)
        {
            return await client.GetFromJsonAsync<Project>("api/project/getprojectbyid?id=" + id);
        }

        public async Task AddProjectAsync(Project project)
        {
            await client.PostAsJsonAsync("api/project", project);
        }

        public async Task RemoveProjectAsync(Project project)
        {
            await client.PostAsJsonAsync("api/project/removeproject", project);
        }

        public async Task EditProjectAsync(Project project)
        {
            await client.PostAsJsonAsync("api/project/editproject", project);
        }
    }
}
