using System.Runtime.CompilerServices;

namespace PlanningInfoSystemAPI
{
    public class ProductClassification
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedDateTime { get; set; }
        public DateTime LastModifiedDateTime { get; set; }
    }
}
