using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MyPortfolio.Shared
{
    public class Project
    {

        public Project() { }

        public Project(Project project)
        {
            this.Id = project.Id;
            this.Title = project.Title;
            this.Requirements = project.Requirements;
            this.Description = project.Description;
            this.CompletionDate = DateTime.Now;
            this.Slug = project.Slug;
        }

        public const string LanguageSkill = "language";
        public const string PlatformSkill = "platform";
        public const string TechnologySkill = "technology";

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [Required]
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("requirements")]
        public string Requirements { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("completion_date")]
        public DateTime CompletionDate { get; set; }
        public List<ProjectLanguage> ProjectLanguages { get; set; }
        public string Slug { get; set; }
    }
}
