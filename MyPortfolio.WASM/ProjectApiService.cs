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
            return await client.GetFromJsonAsync<IEnumerable<Project>>("api/project");
        }

        public async Task<IEnumerable<Language>> GetLanguagesAsync()
        {
            return await client.GetFromJsonAsync<IEnumerable<Language>>("api/project/getlanguages");
        }

        public async Task<IEnumerable<Platform>> GetPlatformsAsync()
        {
            return await client.GetFromJsonAsync<IEnumerable<Platform>>("api/project/getplatforms");
        }

        public async Task<IEnumerable<Technology>> GetTechnologiesAsync()
        {
            return await client.GetFromJsonAsync<IEnumerable<Technology>>("api/project/gettechnologies");
        }

        public async Task<Project> GetProjectBySlugAsync(string slug)
        {
            return await client.GetFromJsonAsync<Project>($"api/project/{slug}");
        }

        public async Task<Project> GetProjectByIdAsync(int id)
        {
            return await client.GetFromJsonAsync<Project>("api/project/getprojectbyid?id=" + id);
        }

        public async Task<Language> GetLanguageByIdAsync(int id)
        {
            return await client.GetFromJsonAsync<Language>("api/project/getlanguagebyid?id=" + id);
        }

        public async Task<Platform> GetPlatformByIdAsync(int id)
        {
            return await client.GetFromJsonAsync<Platform>("api/project/getplatformbyid?id=" + id);
        }

        public async Task<Technology> GetTechnologyByIdAsync(int id)
        {
            return await client.GetFromJsonAsync<Technology>("api/project/gettechnologybyid?id=" + id);
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

        public async Task AssignAsync(string skillType, int projectId, string newName)
        {
            var assignBody = new AssignRequest
            {
                SkillType = skillType,
                Name = newName,
                ProjectId = projectId
            };
            await client.PostAsJsonAsync($"api/project/assign/", assignBody);
        }

        public async Task<IEnumerable<Language>> GetLanguagesByProjectAsync(int id)
        {
            return await client.GetFromJsonAsync<IEnumerable<Language>>("api/project/getlanguagebyproduct?id=" + id);
        }

        public async Task<IEnumerable<Platform>> GetPlatformsByProjectAsync(int id)
        {
            return await client.GetFromJsonAsync<IEnumerable<Platform>>("api/project/getplatformbyproduct?id=" + id);
        }

        public async Task<IEnumerable<Technology>> GetTechsByProjectAsync(int id)
        {
            return await client.GetFromJsonAsync<IEnumerable<Technology>>("api/project/gettechbyproduct?id=" + id);
        }

        public async Task<IEnumerable<Project>> GetProjectsByLanguageAsync(int id)
        {
            return await client.GetFromJsonAsync<IEnumerable<Project>>("api/project/getprojectbylanguage?id=" + id);
        }

        public async Task<IEnumerable<Project>> GetProjectsByPlatformAsync(int id)
        {
            return await client.GetFromJsonAsync<IEnumerable<Project>>("api/project/getprojectbyplatform?id=" + id);
        }

        public async Task<IEnumerable<Project>> GetProjectsByTechnologyAsync(int id)
        {
            return await client.GetFromJsonAsync<IEnumerable<Project>>("api/project/getprojectbytechnology?id=" + id);
        }
    }
}
