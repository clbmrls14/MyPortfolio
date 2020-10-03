namespace MyPortfolio.Shared
{
    public class ProjectPlatform
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int PlatformId { get; set; }
        public Platform Platform { get; set; }
    }
}
