using MyPortfolio.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPortfolio.API.Data
{
    public class EFCoreRepository : IRepository
    {
        private readonly ApplicationDbContext context;

        public EFCoreRepository(ApplicationDbContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        // BEGIN PROJECT CRUD METHODS
        public IQueryable<Project> Projects => context.Projects;

        public async Task SaveProjectAsync(Project project)
        {
            context.Projects.Add(project);
            await context.SaveChangesAsync();
        }

        public async Task RemoveProjectAsync(Project project)
        {
            context.Projects.Remove(project);
            await context.SaveChangesAsync();
        }

        public async Task EditProjectAsync(Project project)
        {
            context.Projects.Update(project);
            await context.SaveChangesAsync();
        }
        // END PROJECT CRUD METHODS
        // ######
        // BEGIN SKILL CRUD METHODS
        public async Task AddSkillAsync(Skill skill)
        {
            context.Skills.Add(skill);
            await context.SaveChangesAsync();
        }
        // END SKILL CRUD METHODS
        // ######
        // BEGIN PROJECTSKILL CRUD METHODS
        public async Task AssignSkillAsync(ProjectSkill projectSkill)
        {
            context.ProjectSkills.Add(projectSkill);
            await context.SaveChangesAsync();
        }
        // END PROJECTSKILL CRUD METHODS
    }
}
