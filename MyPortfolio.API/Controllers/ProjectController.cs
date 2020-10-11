using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        // GET OBJECTS
        [HttpGet()]
        public async Task<List<Project>> Get() => await repository.Projects.ToListAsync();

        [HttpGet("{slug}")]
        public async Task<Project> GetProject(string slug)
        {
            try
            {
                return await repository.Projects.FirstOrDefaultAsync(p => p.Slug == slug);
            } catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet("[action]")]
        public async Task<List<Language>> GetLanguages() => await repository.Languages.ToListAsync();

        [HttpGet("[action]")]
        public async Task<List<Platform>> GetPlatforms() => await repository.Platforms.ToListAsync();

        [HttpGet("[action]")]
        public async Task<List<Technology>> GetTechnologies() => await repository.Technologies.ToListAsync();

        // GET OBJECT BY ID
        [HttpGet("[action]")]
        public async Task<Project> GetProjectById(int id) => await repository.Projects.Where(p => p.Id == id).FirstOrDefaultAsync();

        [HttpGet("[action]")]
        public async Task<Language> GetLanguageById(int id) => await repository.Languages.Where(l => l.Id == id).FirstOrDefaultAsync();

        [HttpGet("[action]/{slug}")]
        public async Task<Language> GetLanguageBySlug(string slug) => await repository.Languages.Where(l => l.Slug == slug).FirstOrDefaultAsync();

        [HttpGet("[action]")]
        public async Task<Platform> GetPlatformById(int id) => await repository.Platforms.Where(p => p.Id == id).FirstOrDefaultAsync();

        [HttpGet("[action]/{slug}")]
        public async Task<Platform> GetPlatformBySlug(string slug) => await repository.Platforms.Where(p => p.Slug == slug).FirstOrDefaultAsync();

        [HttpGet("[action]")]
        public async Task<Technology> GetTechnologyById(int id) => await repository.Technologies.Where(t => t.Id == id).FirstOrDefaultAsync();

        [HttpGet("[action]/{slug}")]
        public async Task<Technology> GetTechnologyBySlug(string slug) => await repository.Technologies.Where(t => t.Slug == slug).FirstOrDefaultAsync();

        // GET PROJECTS FROM SKILLS
        [HttpGet("[action]")]
        public async Task<List<Project>> GetProjectByLanguage(int id) => await repository.ProjectLanguages.Where(pl => pl.LanguageId == id).Select(p => p.Project).ToListAsync();

        [HttpGet("[action]")]
        public async Task<List<Project>> GetProjectByPlatform(int id) => await repository.ProjectPlatforms.Where(pp => pp.PlatformId == id).Select(p => p.Project).ToListAsync();

        [HttpGet("[action]")]
        public async Task<List<Project>> GetProjectByTechnology(int id) => await repository.ProjectTechnologies.Where(pt => pt.TechnologyId == id).Select(p => p.Project).ToListAsync();

        // GET SKILLS FROM PROJECTS
        [HttpGet("[action]")]
        public async Task<List<Language>> GetLanguageByProduct(int id) => await repository.ProjectLanguages.Where(pl => pl.ProjectId == id).Select(l => l.Language).ToListAsync();

        [HttpGet("[action]")]
        public async Task<List<Platform>> GetPlatformByProduct(int id) => await repository.ProjectPlatforms.Where(pp => pp.ProjectId == id).Select(p => p.Platform).ToListAsync();

        [HttpGet("[action]")]
        public async Task<List<Technology>> GetTechByProduct(int id) => await repository.ProjectTechnologies.Where(pt => pt.ProjectId == id).Select(t => t.Technology).ToListAsync();

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
        public async Task Post(Project project) => await repository.SaveProjectAsync(project);

        [HttpPost("[action]")]
        public async Task RemoveProject(Project project) => await repository.RemoveProjectAsync(project);

        [HttpPost("[action]")]
        public async Task EditProject(Project project) => await repository.EditProjectAsync(project);

        [HttpPost("[action]")]
        public async Task Assign(AssignRequest assignRequest) => await repository.AssignSkillAsync(assignRequest);
    }
}
