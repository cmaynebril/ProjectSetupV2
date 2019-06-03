﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectSetupV2.Models.Context;

namespace ProjectSetupV2.Migrations
{
    [DbContext(typeof(DBProjectSetupContext))]
    [Migration("20190531012734_DeleteTaskStatus")]
    partial class DeleteTaskStatus
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProjectSetupV2.Models.Context.Assignees", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Assignee");

                    b.Property<long?>("AssigneeRate");

                    b.HasKey("Id");

                    b.ToTable("Assignees");
                });

            modelBuilder.Entity("ProjectSetupV2.Models.Context.BusinessValues", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Business")
                        .IsRequired()
                        .HasColumnName("business")
                        .HasColumnType("text");

                    b.Property<double>("Rate")
                        .HasColumnName("rate");

                    b.HasKey("Id");

                    b.ToTable("BusinessValues");
                });

            modelBuilder.Entity("ProjectSetupV2.Models.Context.Clients", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Client")
                        .IsRequired()
                        .HasColumnName("client")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("ProjectSetupV2.Models.Context.JobStatus", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Status");

                    b.HasKey("Id");

                    b.ToTable("JobStatus");
                });

            modelBuilder.Entity("ProjectSetupV2.Models.Context.Jobs", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("ClientId");

                    b.Property<string>("ClientName")
                        .HasColumnType("text");

                    b.Property<string>("Job")
                        .HasColumnName("job")
                        .HasColumnType("text");

                    b.Property<double?>("JobRate");

                    b.Property<string>("JobStatus");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("ProjectSetupV2.Models.Context.Tasks", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("BusinessValuesId");

                    b.Property<long?>("JobId")
                        .HasColumnName("jobId");

                    b.Property<string>("Status");

                    b.Property<string>("Task")
                        .HasColumnName("task")
                        .HasColumnType("text");

                    b.Property<double?>("TasksRate");

                    b.HasKey("Id");

                    b.HasIndex("BusinessValuesId");

                    b.HasIndex("JobId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("ProjectSetupV2.Models.Context.Timesheet", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("AssigneeId");

                    b.Property<long>("BusinessValueId");

                    b.Property<long>("ClientId");

                    b.Property<DateTime?>("Date");

                    b.Property<string>("Description");

                    b.Property<long>("JobId");

                    b.Property<string>("Status");

                    b.Property<long>("TaskId");

                    b.Property<double>("TimeSpent");

                    b.HasKey("Id");

                    b.ToTable("Timesheet");
                });

            modelBuilder.Entity("ProjectSetupV2.Models.Context.Jobs", b =>
                {
                    b.HasOne("ProjectSetupV2.Models.Context.Clients", "Client")
                        .WithMany("Jobs")
                        .HasForeignKey("ClientId")
                        .HasConstraintName("FK__Projects__Custom__398D8EEE");
                });

            modelBuilder.Entity("ProjectSetupV2.Models.Context.Tasks", b =>
                {
                    b.HasOne("ProjectSetupV2.Models.Context.BusinessValues", "BusinessValues")
                        .WithMany("Tasks")
                        .HasForeignKey("BusinessValuesId")
                        .HasConstraintName("FK__Tasks__Id__3F466844");

                    b.HasOne("ProjectSetupV2.Models.Context.Jobs", "Job")
                        .WithMany("Tasks")
                        .HasForeignKey("JobId")
                        .HasConstraintName("FK__Tasks__Id__3E52440B");
                });
#pragma warning restore 612, 618
        }
    }
}
