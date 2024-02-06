namespace PlanningInfoSystemAPI
{
    public class DowntimeGuide
    {
        public int Id { get; set; }
        public string Classification { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Accountability { get; set; } = string.Empty;
        public DateTime CreatedDateTime { get; set; }
        public DateTime LastModifiedDateTime { get; set; }
    }
}
