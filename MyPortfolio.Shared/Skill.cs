using System;
using System.Collections.Generic;
using System.Text;

namespace MyPortfolio.Shared
{
    public class Skill
    {
        public int Id { get; set; }
        public string SkillTitle { get; set; }
        public List<Project> RelevantProjects { get; set; }

    }
}
