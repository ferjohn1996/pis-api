namespace PlanningInfoSystemAPI.Models.Packing
{
    public class PackingDto
    {
        public int Id { get; set; }
        public string? PackingId { get; set; }
        public DateTime ProdDate { get; set; }
        public int? Feed_Run_No { get; set; }
        public string? Feed_Code { get; set; }
        public string? Feed_Name { get; set; }
        public int? Feed_ActualTons { get; set; }
        public string? Feed_Forms { get; set; }
        public int? Feed_BagWT { get; set; }
        public TimeSpan Product_PackStart { get; set; }
        public TimeSpan Product_PackStop { get; set; }
        public double? Product_TotalHours { get; set; }
        public double? Product_TonsHours { get; set; }
        public string? Product_STD { get; set; }
        public double? Yield_ExpectedNoBags { get; set; }
        public string? Yield_Completion { get; set; }
        public double? Yield_RemainingTons { get; set; }
        public int? Yield_ActualBags { get; set; }
        public int? Yield_SOKgs { get; set; }
        public int? Yield_SBKgs { get; set; }
        public int? Yield_RejectedBags { get; set; }
        public double? Yield_ActualYield { get; set; }
        public string? Operator_Int { get; set; }
        public string? Operator_Shift { get; set; }
        public double? Downtime_Hours { get; set; }
        public string? Downtime_Type { get; set; }
        public string? Downtime_Accountability { get; set; }
        public string? Downtime_Remarks { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime LastModifiedDateTime { get; set; }
    }
}
