using Microsoft.EntityFrameworkCore;
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
        // BEGIN ASSIGNREQUEST CRUD METHODS
        public async Task AssignSkillAsync(AssignRequest assignRequest)
        {
            switch (assignRequest.SkillType)
            {
                case Project.LanguageSkill:
                    var language = await context.Languages.FirstOrDefaultAsync(l => l.Name == assignRequest.Name);
                    if (language == null)
                    {
                        language = new Language { Name = assignRequest.Name };
                        context.Languages.Add(language);
                        await context.SaveChangesAsync();
                    }
                    var lc = new ProjectLanguage
                    {
                        ProjectId = assignRequest.ProjectId,
                        LanguageId = language.Id
                    };
                    context.ProjectLanguages.Add(lc);
                    await context.SaveChangesAsync();
                    break;
                default:
                    break;
            }
        }
        // END PROJECTSKILL CRUD METHODS
    }
}
