﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PlanningInfoSystemAPI.Data;

#nullable disable

namespace PlanningInfoSystemAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240201035522_14")]
    partial class _14
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PlanningInfoSystemAPI.DowntimeGuide", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Accountability")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Classification")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastModifiedDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("DowntimeGuide");
                });

            modelBuilder.Entity("PlanningInfoSystemAPI.Models.Batching.Batching", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ActualTons")
                        .HasColumnType("int");

                    b.Property<string>("Bin_To")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Downtime_Accountability")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Downtime_Hours")
                        .HasColumnType("float");

                    b.Property<string>("Downtime_Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Downtime_Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FeedCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FeedName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Forms")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Formula_Date")
                        .HasColumnType("int");

                    b.Property<int?>("Formula_Ver")
                        .HasColumnType("int");

                    b.Property<double?>("HammerMill_screen1")
                        .HasColumnType("float");

                    b.Property<double?>("HammerMill_screen2")
                        .HasColumnType("float");

                    b.Property<double?>("MixProd_STD")
                        .HasColumnType("float");

                    b.Property<TimeSpan>("MixProd_TimeStart")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("MixProd_TimeStop")
                        .HasColumnType("time");

                    b.Property<double?>("MixProd_TonsHours")
                        .HasColumnType("float");

                    b.Property<double?>("MixProd_TotalHours")
                        .HasColumnType("float");

                    b.Property<DateTime>("ProdDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ProdSchedule")
                        .HasColumnType("datetime2");

                    b.Property<string>("ProdTeam_Dump1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProdTeam_Dump2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProdTeam_Dump3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProdTeam_Optr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProdTeam_ShiftVisor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("ReworkAdd_Kilos")
                        .HasColumnType("float");

                    b.Property<string>("ReworkAdd_LotId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Run_No")
                        .HasColumnType("int");

                    b.Property<string>("Setup_BTC_Size")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Setup_Feedrate_max")
                        .HasColumnType("int");

                    b.Property<int>("Setup_Feedrate_min")
                        .HasColumnType("int");

                    b.Property<string>("Setup_H2O")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Setup_Motor_load")
                        .HasColumnType("int");

                    b.Property<double?>("Setup_NoBatches")
                        .HasColumnType("float");

                    b.Property<int>("Setup_RPM")
                        .HasColumnType("int");

                    b.Property<string>("Sub_Batch")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Batching");
                });

            modelBuilder.Entity("PlanningInfoSystemAPI.Models.Planning.PlanningRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("PlanningBatchId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PlanningRequest");
                });

            modelBuilder.Entity("PlanningInfoSystemAPI.Models.Planning.PlanningRequestLine1Tbl", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Accountability")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ActualHours")
                        .HasColumnType("int");

                    b.Property<double?>("ChangeOver")
                        .HasColumnType("float");

                    b.Property<string>("DelayStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DieSizeThickness")
                        .HasColumnType("int");

                    b.Property<string>("DowntimeGuide")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("EffectiveCapacity")
                        .HasColumnType("float");

                    b.Property<string>("Form")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MT")
                        .HasColumnType("int");

                    b.Property<int>("PlanningId")
                        .HasColumnType("int");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SKU")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("TimeProduce")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("PlanningId");

                    b.ToTable("PlanningRequestLine1Tbl");
                });

            modelBuilder.Entity("PlanningInfoSystemAPI.Models.Planning.PlanningRequestLine2Tbl", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Accountability")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ActualHours")
                        .HasColumnType("int");

                    b.Property<double?>("ChangeOver")
                        .HasColumnType("float");

                    b.Property<string>("DelayStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DieSizeThickness")
                        .HasColumnType("int");

                    b.Property<string>("DowntimeGuide")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("EffectiveCapacity")
                        .HasColumnType("float");

                    b.Property<string>("Form")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MT")
                        .HasColumnType("int");

                    b.Property<int>("PlanningId")
                        .HasColumnType("int");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SKU")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("TimeProduce")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("PlanningId");

                    b.ToTable("PlanningRequestLine2Tbl");
                });

            modelBuilder.Entity("PlanningInfoSystemAPI.Models.Planning.PlanningRequestLine3Tbl", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Accountability")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ActualHours")
                        .HasColumnType("int");

                    b.Property<double?>("ChangeOver")
                        .HasColumnType("float");

                    b.Property<string>("DelayStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DieSizeThickness")
                        .HasColumnType("int");

                    b.Property<string>("DowntimeGuide")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("EffectiveCapacity")
                        .HasColumnType("float");

                    b.Property<string>("Form")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MT")
                        .HasColumnType("int");

                    b.Property<int>("PlanningId")
                        .HasColumnType("int");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SKU")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("TimeProduce")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("PlanningId");

                    b.ToTable("PlanningRequestLine3Tbl");
                });

            modelBuilder.Entity("PlanningInfoSystemAPI.ProductClassification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastModifiedDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("ProductClassifications");
                });

            modelBuilder.Entity("PlanningInfoSystemAPI.Models.Planning.PlanningRequestLine1Tbl", b =>
                {
                    b.HasOne("PlanningInfoSystemAPI.Models.Planning.PlanningRequest", "Planning")
                        .WithMany("Line1")
                        .HasForeignKey("PlanningId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Planning");
                });

            modelBuilder.Entity("PlanningInfoSystemAPI.Models.Planning.PlanningRequestLine2Tbl", b =>
                {
                    b.HasOne("PlanningInfoSystemAPI.Models.Planning.PlanningRequest", "Planning")
                        .WithMany("Line2")
                        .HasForeignKey("PlanningId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Planning");
                });

            modelBuilder.Entity("PlanningInfoSystemAPI.Models.Planning.PlanningRequestLine3Tbl", b =>
                {
                    b.HasOne("PlanningInfoSystemAPI.Models.Planning.PlanningRequest", "Planning")
                        .WithMany("Line3")
                        .HasForeignKey("PlanningId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Planning");
                });

            modelBuilder.Entity("PlanningInfoSystemAPI.Models.Planning.PlanningRequest", b =>
                {
                    b.Navigation("Line1");

                    b.Navigation("Line2");

                    b.Navigation("Line3");
                });
#pragma warning restore 612, 618
        }
    }
}
