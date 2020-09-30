using System;
using System.Collections.Generic;
using System.Text;

namespace MyPortfolio.Shared
{
    public class ProjectSkill
    {
        public int Id { get; set; }
        public int SkillId { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public Skill Skill { get; set; }
    }
}
