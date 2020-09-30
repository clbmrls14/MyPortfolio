using MyPortfolio.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPortfolio.API.Data
{
    public interface IRepository
    {
        IQueryable<Project> Projects { get; }
        Task SaveProjectAsync(Project project);
        Task RemoveProjectAsync(Project project);
        Task EditProjectAsync(Project project);
        Task AddSkillAsync(Skill skill);
        Task AssignSkillAsync(ProjectSkill projectSkill);
    }
}
