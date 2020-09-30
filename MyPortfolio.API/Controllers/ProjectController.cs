using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.Shared;
using MyPortfolio.API.Data;

namespace MyPortfolio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IRepository repository;

        public ProjectController(IRepository repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet()]
        public async Task<List<Project>> Get() => await repository.Projects.ToListAsync();

        [HttpGet("[action]")]
        public async Task<Project> GetProjectById(int id) => await repository.Projects.Where(p => p.Id == id).FirstOrDefaultAsync();

        [HttpGet("[action]")]
        public async Task DefaultData()
        {
            await repository.SaveProjectAsync(new Project
            {
                Title = "Project Default",
                Requirements = "Demonstrate APIs with a database",
                Description = "This Portfolio is built with a Blazor front end and a C# API"
            });


            await repository.SaveProjectAsync(new Project
            {
                Title = "Demo Project",
                Requirements = "Demo a project",
                Description = "This project was built as a demo!"
            });
        }

        [HttpPost()]
        public async Task Post(Project project)
        {
            await repository.SaveProjectAsync(project);
        }

        [HttpPost("[action]")]
        public async Task RemoveProject(Project project)
        {
            await repository.RemoveProjectAsync(project);
        }

        [HttpPost("[action]")]
        public async Task EditProject(Project project)
        {
            await repository.EditProjectAsync(project);
        }

        [HttpPost("[action]")]
        public async Task AssignSkill(ProjectSkill projectSkill)
        {
            await repository.AssignSkillAsync(projectSkill);
        }
    }
}
