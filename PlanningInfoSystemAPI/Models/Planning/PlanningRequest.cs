using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json; // Import Newtonsoft.Json for JsonIgnore attribute
using System.Threading.Tasks;

namespace PlanningInfoSystemAPI.Models.Planning
{

    public class PlanningRequest
    {
        public static int LastUsedId = 1000; // Starting value for auto-incrementing ID

        public int Id { get; set; }
        public string PlanningBatchId { get; set; }
        [JsonIgnore]
        public List<PlanningRequestLine1Tbl>? Line1 { get; set; }
        [JsonIgnore]
        public List<PlanningRequestLine2Tbl>? Line2 { get; set; }
        [JsonIgnore]
        public List<PlanningRequestLine3Tbl>? Line3 { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public DateTime? LastModifiedDateTime { get; set; }

        public PlanningRequest()
        {
            PlanningBatchId = $"PB-{++LastUsedId:D5}"; // Format and auto-increment
        }
    }

    public class PlanningRequestLine1Tbl
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
        public PlanningRequest Planning { get; set; }
    }

    public class PlanningRequestLine2Tbl
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
        public PlanningRequest Planning { get; set; }
    }

    public class PlanningRequestLine3Tbl
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
        public PlanningRequest Planning { get; set; }
    }
}
