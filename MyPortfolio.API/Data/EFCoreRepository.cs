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
        // BEGIN SKILL CRUD METHODS
        public IQueryable<Language> Languages => context.Languages;
        public IQueryable<Platform> Platforms => context.Platforms;
        public IQueryable<Technology> Technologies => context.Technologies;

        public IQueryable<ProjectLanguage> ProjectLanguages => context.ProjectLanguages;
        public IQueryable<ProjectPlatform> ProjectPlatforms => context.ProjectPlatforms;
        public IQueryable<ProjectTechnology> ProjectTechnologies => context.ProjectTechnologies;
        // END SKILL CRUD METHODS
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
                    var pl = new ProjectLanguage
                    {
                        ProjectId = assignRequest.ProjectId,
                        LanguageId = language.Id
                    };
                    context.ProjectLanguages.Add(pl);
                    await context.SaveChangesAsync();
                    break;
                case Project.PlatformSkill:
                    var platform = await context.Platforms.FirstOrDefaultAsync(l => l.Name == assignRequest.Name);
                    if (platform == null)
                    {
                        platform = new Platform { Name = assignRequest.Name };
                        context.Platforms.Add(platform);
                        await context.SaveChangesAsync();
                    }
                    var pp = new ProjectPlatform
                    {
                        ProjectId = assignRequest.ProjectId,
                        PlatformId = platform.Id
                    };
                    context.ProjectPlatforms.Add(pp);
                    await context.SaveChangesAsync();
                    break;
                case Project.TechnologySkill:
                    var technology = await context.Technologies.FirstOrDefaultAsync(l => l.Name == assignRequest.Name);
                    if (technology == null)
                    {
                        technology = new Technology { Name = assignRequest.Name };
                        context.Technologies.Add(technology);
                        await context.SaveChangesAsync();
                    }
                    var pt = new ProjectTechnology
                    {
                        ProjectId = assignRequest.ProjectId,
                        TechnologyId = technology.Id
                    };
                    context.ProjectTechnologies.Add(pt);
                    await context.SaveChangesAsync();
                    break;
                default:
                    break;
            }
        }
        // END PROJECTSKILL CRUD METHODS
    }
}
