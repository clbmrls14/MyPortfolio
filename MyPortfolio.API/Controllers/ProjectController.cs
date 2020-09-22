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
        public async Task DefaultData()
        {
            await repository.SaveProjectAsync(new Project
            {
                Title = "This Portfolio",
                Requirements = "Demonstrate APIs with a database",
                Description = "This Portfolio is built with a Blazor front end and a C# API"
            });


            await repository.SaveProjectAsync(new Project
            {
                Title = "Gutenburg Concordance",
                Requirements = "Elixir",
                Description = "This project was built in Elixir using GenServers"
            });
        }

        [HttpPost()]
        public async Task Post(Project project)
        {
            await repository.SaveProjectAsync(project);
        }
    }
}
