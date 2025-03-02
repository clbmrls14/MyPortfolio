﻿using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
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
    public class AuthenticatedProjectApiService
    {
        private readonly HttpClient client;

        public AuthenticatedProjectApiService(HttpClient client)
        {
            this.client = client;
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
    }
}
