﻿// <auto-generated />
using System;
using JobPostingBrowser.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JobPostingBrowser.Api.Migrations
{
    [DbContext(typeof(JobContext))]
    partial class JobContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.4");

            modelBuilder.Entity("JobPostingBrowser.Core.JobDetails", b =>
                {
                    b.Property<int?>("JobId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ApplicationCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ContractType")
                        .HasColumnType("TEXT");

                    b.Property<string>("DatePosted")
                        .HasColumnType("TEXT");

                    b.Property<int?>("EmployerId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("EmployerName")
                        .HasColumnType("TEXT");

                    b.Property<string>("ExternalUrl")
                        .HasColumnType("TEXT");

                    b.Property<string>("JobDescription")
                        .HasColumnType("TEXT");

                    b.Property<string>("JobTitle")
                        .HasColumnType("TEXT");

                    b.Property<string>("JobUrl")
                        .HasColumnType("TEXT");

                    b.Property<string>("LocationName")
                        .HasColumnType("TEXT");

                    b.Property<double?>("MaximumSalary")
                        .HasColumnType("REAL");

                    b.Property<double?>("MinimumSalary")
                        .HasColumnType("REAL");

                    b.HasKey("JobId");

                    b.ToTable("JobDetailsSet");
                });
#pragma warning restore 612, 618
        }
    }
}