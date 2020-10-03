namespace MyPortfolio.Shared
{
    public class ProjectTechnology
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int TechnologyId { get; set; }
        public Technology Technology { get; set; }
    }
}
