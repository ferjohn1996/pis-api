namespace PlanningInfoSystemAPI.Models.Batching
{
    public class BatchingResponseDTO
    {
        public int Id { get; set; }
        public string BatchingId { get; set; }
        public string Description { get; set; }
        public int? statusId { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public DateTime? LastModifiedDateTime { get; set; }
    }
    public class BatchingDTO
    {
        public int Id { get; set; }
        public string BatchingId { get; set; }
        public string Description { get; set; }
        public int? statusId { get; set; }
        public List<Batching1> Batch1 { get; set; }
        public List<Batching2> Batch2 { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public DateTime? LastModifiedDateTime { get; set; }
    }

    public class Batching1DTO
    {
        public int Id { get; set; }
        public int BatchId { get; set; }
        public DateTime? ProdDate { get; set; }
        public DateTime? ProdSchedule { get; set; }
        public int? Run_No { get; set; }
        public string? Sub_Batch { get; set; }
        public string? FeedCode { get; set; }
        public int? Formula_Ver { get; set; }
        public int? Formula_Date { get; set; }
        public string? FeedName { get; set; }
        public int? ActualTons { get; set; }
        public string? Forms { get; set; }
        public double? Setup_NoBatches { get; set; }
        public string? Setup_BTC_Size { get; set; }
        public int Setup_Feedrate_min { get; set; }
        public int Setup_Feedrate_max { get; set; }
        public int Setup_Motor_load { get; set; }
        public string? Setup_H2O { get; set; }
        public int Setup_RPM { get; set; }
        public double? HammerMill_screen1 { get; set; }
        public double? HammerMill_screen2 { get; set; }
        public TimeSpan MixProd_TimeStart { get; set; }
        public TimeSpan MixProd_TimeStop { get; set; }
        public double? MixProd_TotalHours { get; set; }
        public double? MixProd_TonsHours { get; set; }
        public string? MixProd_STD { get; set; }
        public string? ReworkAdd_LotId { get; set; }
        public double? ReworkAdd_Kilos { get; set; }
        public string? Bin_To { get; set; }
        public string? ProdTeam_Optr { get; set; }
        public string? ProdTeam_ShiftVisor { get; set; }
        public string? ProdTeam_Dump1 { get; set; }
        public string? ProdTeam_Dump2 { get; set; }
        public string? ProdTeam_Dump3 { get; set; }
        public double? Downtime_Hours { get; set; }
        public string? Downtime_Type { get; set; }
        public string? Downtime_Accountability { get; set; }
        public string? Downtime_Remarks { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public DateTime? LastModifiedDateTime { get; set; }
    }

    public class Batching2DTO
    {
        public int Id { get; set; }
        public int BatchId { get; set; }
        public DateTime? ProdDate { get; set; }
        public DateTime? ProdSchedule { get; set; }
        public int? Run_No { get; set; }
        public string? Sub_Batch { get; set; }
        public string? FeedCode { get; set; }
        public int? Formula_Ver { get; set; }
        public int? Formula_Date { get; set; }
        public string? FeedName { get; set; }
        public int? ActualTons { get; set; }
        public string? Forms { get; set; }
        public double? Setup_NoBatches { get; set; }
        public string? Setup_BTC_Size { get; set; }
        public int Setup_Feedrate_min { get; set; }
        public int Setup_Feedrate_max { get; set; }
        public int Setup_Motor_load { get; set; }
        public string? Setup_H2O { get; set; }
        public int Setup_RPM { get; set; }
        public double? HammerMill_screen1 { get; set; }
        public double? HammerMill_screen2 { get; set; }
        public TimeSpan MixProd_TimeStart { get; set; }
        public TimeSpan MixProd_TimeStop { get; set; }
        public double? MixProd_TotalHours { get; set; }
        public double? MixProd_TonsHours { get; set; }
        public string? MixProd_STD { get; set; }
        public string? ReworkAdd_LotId { get; set; }
        public double? ReworkAdd_Kilos { get; set; }
        public string? Bin_To { get; set; }
        public string? ProdTeam_Optr { get; set; }
        public string? ProdTeam_ShiftVisor { get; set; }
        public string? ProdTeam_Dump1 { get; set; }
        public string? ProdTeam_Dump2 { get; set; }
        public string? ProdTeam_Dump3 { get; set; }
        public double? Downtime_Hours { get; set; }
        public string? Downtime_Type { get; set; }
        public string? Downtime_Accountability { get; set; }
        public string? Downtime_Remarks { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public DateTime? LastModifiedDateTime { get; set; }
    }
}
