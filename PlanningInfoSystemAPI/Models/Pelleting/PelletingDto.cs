namespace PlanningInfoSystemAPI.Models.Pelleting
{
    public class PelletingDto
    {
        public int Id { get; set; }
        public string? PelletingId { get; set; }
        public DateTime ProdDate { get; set; }
        public int? Feed_Run_No { get; set; }
        public string? Feed_Code { get; set; }
        public string? Feed_Name_Medication { get; set; }
        public int? Feed_Actual_Tons { get; set; }
        public string? Feed_Forms { get; set; }
        public int? Feed_Bin_Mash { get; set; }
        public int? Feed_Bin_Ff { get; set; }
        public string? Feed_Optr_Init { get; set; }
        public string? Feed_Optr_Visor { get; set; }
        public TimeSpan Pellet_Start { get; set; }
        public TimeSpan Pellet_Stop { get; set; }
        public double? Pellet_Total_Hours { get; set; }
        public double? Pellet_Tons_TPH { get; set; }
        public string? Pellet_STD { get; set; }
        public double? Mill_Feeder_Setting { get; set; }
        public double? Mill_Steam_Setpoint { get; set; }
        public double? Mill_Steam_PSI { get; set; }
        public double? Mill_Ret_Team { get; set; }
        public double? Mill_Amps_Load { get; set; }
        public double? Cooler_Bed_Depth { get; set; }
        public double? Cooler_Air_Opening { get; set; }
        public double? Cooler_Cool_Speed { get; set; }
        public double? Downtime_Hours { get; set; }
        public string? Downtime_Type { get; set; }
        public string? Downtime_Accountability { get; set; }
        public string? Downtime_Remarks { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime LastModifiedDateTime { get; set; }
    }
}
