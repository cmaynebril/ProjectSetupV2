﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectSetupV2.Models.Context;

namespace ProjectSetupV2.Migrations
{
    [DbContext(typeof(DBProjectSetupContext))]
    partial class DBProjectSetupContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("ProjectSetupV2.Models.Context.Staffs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("StaffName")
                        .HasColumnType("text");

                    b.Property<long?>("StaffRate");

                    b.Property<long?>("TaskId");

                    b.HasKey("Id");

                    b.HasIndex("TaskId");

                    b.ToTable("Staffs");
                });

            modelBuilder.Entity("ProjectSetupV2.Models.Context.Tasks", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("BusinessValuesId");

                    b.Property<long?>("JobId")
                        .HasColumnName("jobId");

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

            modelBuilder.Entity("ProjectSetupV2.Models.Context.Staffs", b =>
                {
                    b.HasOne("ProjectSetupV2.Models.Context.Tasks", "Task")
                        .WithMany("Staffs")
                        .HasForeignKey("TaskId")
                        .HasConstraintName("FK_Staffs_Tasks");
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
