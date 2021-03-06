// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PandologicAssignment.Models;

#nullable disable

namespace PandologicAssignment.Migrations
{
    [DbContext(typeof(JobContext))]
    [Migration("20211208183229_UpdateDbLocation")]
    partial class UpdateDbLocation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.0");

            modelBuilder.Entity("PandologicAssignment.Models.Job", b =>
                {
                    b.Property<int>("JobId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int>("PredictedViewsPerDay")
                        .HasColumnType("INTEGER");

                    b.HasKey("JobId");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("PandologicAssignment.Models.JobView", b =>
                {
                    b.Property<int>("JobId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("ViewDate")
                        .HasColumnType("TEXT");

                    b.HasKey("JobId");

                    b.ToTable("JobViews");
                });
#pragma warning restore 612, 618
        }
    }
}
