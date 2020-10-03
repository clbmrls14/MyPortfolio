using System;
using System.Collections.Generic;
using System.Text;

namespace MyPortfolio.Shared
{
    public class ProjectLanguage
    {
        public int Id { get; set; }
        public int LanguageId { get; set; }
        public int ProjectId { get; set; }
        public Language Language { get; set; }
        public Project Project { get; set; }
    }
}
