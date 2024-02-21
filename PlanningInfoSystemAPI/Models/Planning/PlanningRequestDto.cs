namespace PlanningInfoSystemAPI.Models.Planning
{
    public class PlanningRequestResponseDTO
    {
        public int Id { get; set; }
        public string PlanningBatchId { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public DateTime? LastModifiedDateTime { get; set; }
    }

    public class PlanningRequestDTO
    {
        public int Id { get; set; }
        public string PlanningBatchId { get; set; }
        public string Description { get; set; }
        public List<PlanningRequestLine1Tbl> Line1 { get; set; }
        public List<PlanningRequestLine2Tbl> Line2 { get; set; }
        public List<PlanningRequestLine3Tbl> Line3 { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public DateTime? LastModifiedDateTime { get; set; }
    }

    public class PlanningRequestLine1DTO
    {
        public int Id { get; set; }
        public int PlanningId { get; set; }
        public string SKU { get; set; }
        public string Description { get; set; }
        public string Form { get; set; }
        public int? MT { get; set; }
        public int? ActualHours { get; set; }
        public double? EffectiveCapacity { get; set; }
        public int? DieSizeThickness { get; set; }
        public double? ChangeOver { get; set; }
        public double? Uncontrollable { get; set; }
        public string? Accountability { get; set; }
        public string? DelayStatus { get; set; }
        public double? TimeProduce { get; set; }
        public string? Remarks { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime LastModifiedDateTime { get; set; }
    }

    public class PlanningRequestLine2DTO
    {
        public int Id { get; set; }
        public int PlanningId { get; set; }
        public string SKU { get; set; }
        public string Description { get; set; }
        public string Form { get; set; }
        public int? MT { get; set; }
        public int? ActualHours { get; set; }
        public double? EffectiveCapacity { get; set; }
        public int? DieSizeThickness { get; set; }
        public double? ChangeOver { get; set; }
        public double? Uncontrollable { get; set; }
        public string? Accountability { get; set; }
        public string? DelayStatus { get; set; }
        public double? TimeProduce { get; set; }
        public string? Remarks { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime LastModifiedDateTime { get; set; }
    }

    public class PlanningRequestLine3DTO
    {
        public int Id { get; set; }
        public int PlanningId { get; set; }
        public string SKU { get; set; }
        public string Description { get; set; }
        public string Form { get; set; }
        public int? MT { get; set; }
        public int? ActualHours { get; set; }
        public double? EffectiveCapacity { get; set; }
        public int? DieSizeThickness { get; set; }
        public double? ChangeOver { get; set; }
        public double? Uncontrollable { get; set; }
        public string? Accountability { get; set; }
        public string? DelayStatus { get; set; }
        public double? TimeProduce { get; set; }
        public string? Remarks { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime LastModifiedDateTime { get; set; }
    }
}
