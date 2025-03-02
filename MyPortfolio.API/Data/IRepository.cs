﻿using MyPortfolio.Shared;
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
        Task AssignSkillAsync(AssignRequest assignRequest);
        IQueryable<ProjectLanguage> ProjectLanguages { get; }
        IQueryable<ProjectPlatform> ProjectPlatforms { get; }
        IQueryable<ProjectTechnology> ProjectTechnologies { get; }
        IQueryable<Language> Languages { get; }
        IQueryable<Platform> Platforms { get; }
        IQueryable<Technology> Technologies { get; }
    }
}
