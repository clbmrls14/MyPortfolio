using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyPortfolio.API.Data;
using MyPortfolio.Shared;

namespace MyPortfolio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillController : ControllerBase
    {
        private readonly IRepository repository;

        public SkillController(IRepository repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpPost("[action]/{skill}")]
        public async Task Add(string skill)
        {
            var newSkill = new Skill()
            {
                SkillTitle = skill
            };
            await repository.AddSkillAsync(newSkill);
        }
    }
}
