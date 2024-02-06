using Microsoft.EntityFrameworkCore;
using PlanningInfoSystemAPI.Models.Batching;
using PlanningInfoSystemAPI.Models.Packing;
using PlanningInfoSystemAPI.Models.Pelleting;
using PlanningInfoSystemAPI.Models.Planning;

namespace PlanningInfoSystemAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<ProductClassification> ProductClassifications => Set<ProductClassification>();

        public DbSet<DowntimeGuide> DowntimeGuide => Set<DowntimeGuide>();

        public DbSet<PlanningRequest> PlanningRequest => Set<PlanningRequest>();
        public DbSet<PlanningRequestLine1Tbl> PlanningRequestLine1Tbl { get; set; }
        public DbSet<PlanningRequestLine2Tbl> PlanningRequestLine2Tbl { get; set; }
        public DbSet<PlanningRequestLine3Tbl> PlanningRequestLine3Tbl { get; set; }
        public DbSet<Batching> Batching { get; set; }
        public DbSet<Pelleting> Pelleting { get; set; }
        public DbSet<Packing> Packing { get; set; }


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<PlanningRequestLine1Tbl>()
        //    .HasOne(_ => _.Planning)
        //    .WithMany(_ => _.Line1)
        //    .HasForeignKey(_ => _.PlanningId);
        //}
    }
}
