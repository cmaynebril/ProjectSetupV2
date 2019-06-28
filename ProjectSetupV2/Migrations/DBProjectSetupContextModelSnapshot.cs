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
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<int>("UserId");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

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
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Business");

                    b.Property<double>("Rate");

                    b.HasKey("Id");

                    b.ToTable("BusinessValues");
                });

            modelBuilder.Entity("ProjectSetupV2.Models.Context.Clients", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Client");

                    b.Property<string>("ContactPerson");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("ProjectSetupV2.Models.Context.InvoiceType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.ToTable("InvoiceType");
                });

            modelBuilder.Entity("ProjectSetupV2.Models.Context.JobStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Status");

                    b.HasKey("Id");

                    b.ToTable("JobStatus");
                });

            modelBuilder.Entity("ProjectSetupV2.Models.Context.JobTasks", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AssigneeId");

                    b.Property<int>("BusinessValueId");

                    b.Property<int>("ClientId");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("Date");

                    b.Property<string>("Description");

                    b.Property<int>("JobId");

                    b.Property<string>("Status");

                    b.Property<int>("TaskId");

                    b.Property<double>("TimeSpent");

                    b.HasKey("Id");

                    b.HasIndex("AssigneeId");

                    b.HasIndex("BusinessValueId");

                    b.HasIndex("ClientId");

                    b.HasIndex("JobId");

                    b.HasIndex("TaskId");

                    b.ToTable("JobTasks");
                });

            modelBuilder.Entity("ProjectSetupV2.Models.Context.Jobs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ClientId");

                    b.Property<string>("ClientName");

                    b.Property<string>("Job");

                    b.Property<double?>("JobRate");

                    b.Property<string>("Status");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("ProjectSetupV2.Models.Context.Leave", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("Date");

                    b.Property<string>("Reason");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("Date");

                    b.Property<string>("Status");

                    b.Property<string>("TypeOfRequest");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Leave");
                });

            modelBuilder.Entity("ProjectSetupV2.Models.Context.LeaveApprover", b =>
                {
                    b.Property<int>("ApproverId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Approver");

                    b.Property<int>("LeaveId");

                    b.Property<string>("Status");

                    b.HasKey("ApproverId");

                    b.HasIndex("LeaveId");

                    b.ToTable("LeaveApprover");
                });

            modelBuilder.Entity("ProjectSetupV2.Models.Context.TaskTimesheet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AssigneeId");

                    b.Property<string>("Billable");

                    b.Property<int>("BusinessValueId");

                    b.Property<int>("ClientId");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("Date");

                    b.Property<string>("Description");

                    b.Property<DateTime>("EndTime");

                    b.Property<int>("JobId");

                    b.Property<DateTime>("StartTime");

                    b.Property<string>("Status");

                    b.Property<int>("TaskId");

                    b.Property<double>("TotalTimeSpent");

                    b.HasKey("Id");

                    b.HasIndex("AssigneeId");

                    b.HasIndex("BusinessValueId");

                    b.HasIndex("ClientId");

                    b.HasIndex("JobId");

                    b.HasIndex("TaskId");

                    b.ToTable("TaskTimesheet");
                });

            modelBuilder.Entity("ProjectSetupV2.Models.Context.Tasks", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BusinessValuesId");

                    b.Property<int>("InvoiceTypeId");

                    b.Property<int?>("JobId");

                    b.Property<string>("Status");

                    b.Property<string>("Task");

                    b.Property<double?>("TasksRate");

                    b.HasKey("Id");

                    b.HasIndex("BusinessValuesId");

                    b.HasIndex("InvoiceTypeId");

                    b.HasIndex("JobId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("ProjectSetupV2.Models.Context.TasksStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Status");

                    b.HasKey("Id");

                    b.ToTable("TasksStatus");
                });

            modelBuilder.Entity("ProjectSetupV2.Models.Context.TimesheetsStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Status");

                    b.HasKey("Id");

                    b.ToTable("TimesheetsStatus");
                });

            modelBuilder.Entity("ProjectSetupV2.Models.Context.TypesOfLeave", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Leave");

                    b.HasKey("Id");

                    b.ToTable("TypesOfLeave");
                });

            modelBuilder.Entity("ProjectSetupV2.Models.Context.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Department");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<int>("ManagerId");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("Position");

                    b.Property<int>("Rate");

                    b.Property<string>("Section");

                    b.Property<string>("SecurityStamp");

                    b.Property<int>("SupervisorId");

                    b.Property<int>("TeamLeaderId");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("ProjectSetupV2.Models.Context.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("ProjectSetupV2.Models.Hardwares.Disk", b =>
                {
                    b.Property<int>("DiskId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<string>("SerialNumber");

                    b.Property<string>("Spec");

                    b.Property<string>("Title");

                    b.Property<string>("Type");

                    b.Property<int>("UserHardwareId");

                    b.HasKey("DiskId");

                    b.HasIndex("UserHardwareId");

                    b.ToTable("Disk");
                });

            modelBuilder.Entity("ProjectSetupV2.Models.Hardwares.Display", b =>
                {
                    b.Property<int>("DisplayId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Manufacturer");

                    b.Property<string>("Name");

                    b.Property<string>("SerialNumber");

                    b.Property<string>("Type");

                    b.Property<int>("UserHardwareId");

                    b.HasKey("DisplayId");

                    b.HasIndex("UserHardwareId");

                    b.ToTable("Display");
                });

            modelBuilder.Entity("ProjectSetupV2.Models.Hardwares.UsbDevice", b =>
                {
                    b.Property<int>("UsbDeviceId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<int>("UserHardwareId");

                    b.HasKey("UsbDeviceId");

                    b.HasIndex("UserHardwareId");

                    b.ToTable("UsbDevice");
                });

            modelBuilder.Entity("ProjectSetupV2.Models.Hardwares.UserHardware", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("TimeStamp");

                    b.HasKey("Id");

                    b.ToTable("UserHardware");
                });

            modelBuilder.Entity("ProjectSetupV2.Models.Softwares.RunningSoftwares", b =>
                {
                    b.Property<int>("SoftwareId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateInstalled");

                    b.Property<int>("MainSoftwareId");

                    b.Property<string>("Name");

                    b.Property<string>("Version");

                    b.HasKey("SoftwareId");

                    b.HasIndex("MainSoftwareId");

                    b.ToTable("RunningSoftwares");
                });

            modelBuilder.Entity("ProjectSetupV2.Models.Softwares.UserSoftware", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("TimeStamp");

                    b.HasKey("Id");

                    b.ToTable("UserSoftware");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("ProjectSetupV2.Models.Context.UserRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("ProjectSetupV2.Models.Context.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("ProjectSetupV2.Models.Context.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("ProjectSetupV2.Models.Context.UserRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProjectSetupV2.Models.Context.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("ProjectSetupV2.Models.Context.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProjectSetupV2.Models.Context.JobTasks", b =>
                {
                    b.HasOne("ProjectSetupV2.Models.Context.User", "User")
                        .WithMany()
                        .HasForeignKey("AssigneeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProjectSetupV2.Models.Context.BusinessValues", "BusinessValue")
                        .WithMany()
                        .HasForeignKey("BusinessValueId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProjectSetupV2.Models.Context.Clients", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProjectSetupV2.Models.Context.Jobs", "Job")
                        .WithMany()
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProjectSetupV2.Models.Context.Tasks", "Task")
                        .WithMany()
                        .HasForeignKey("TaskId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProjectSetupV2.Models.Context.Jobs", b =>
                {
                    b.HasOne("ProjectSetupV2.Models.Context.Clients", "Client")
                        .WithMany("Jobs")
                        .HasForeignKey("ClientId");
                });

            modelBuilder.Entity("ProjectSetupV2.Models.Context.Leave", b =>
                {
                    b.HasOne("ProjectSetupV2.Models.Context.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProjectSetupV2.Models.Context.LeaveApprover", b =>
                {
                    b.HasOne("ProjectSetupV2.Models.Context.Leave", "Leave")
                        .WithMany("LeaveApprover")
                        .HasForeignKey("LeaveId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProjectSetupV2.Models.Context.TaskTimesheet", b =>
                {
                    b.HasOne("ProjectSetupV2.Models.Context.User", "User")
                        .WithMany()
                        .HasForeignKey("AssigneeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProjectSetupV2.Models.Context.BusinessValues", "BusinessValue")
                        .WithMany()
                        .HasForeignKey("BusinessValueId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProjectSetupV2.Models.Context.Clients", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProjectSetupV2.Models.Context.Jobs", "Job")
                        .WithMany()
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProjectSetupV2.Models.Context.Tasks", "Task")
                        .WithMany()
                        .HasForeignKey("TaskId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProjectSetupV2.Models.Context.Tasks", b =>
                {
                    b.HasOne("ProjectSetupV2.Models.Context.BusinessValues", "BusinessValues")
                        .WithMany("Tasks")
                        .HasForeignKey("BusinessValuesId");

                    b.HasOne("ProjectSetupV2.Models.Context.InvoiceType", "InvoiceType")
                        .WithMany()
                        .HasForeignKey("InvoiceTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProjectSetupV2.Models.Context.Jobs", "Job")
                        .WithMany("Tasks")
                        .HasForeignKey("JobId");
                });

            modelBuilder.Entity("ProjectSetupV2.Models.Hardwares.Disk", b =>
                {
                    b.HasOne("ProjectSetupV2.Models.Hardwares.UserHardware", "UserHardware")
                        .WithMany("Disk")
                        .HasForeignKey("UserHardwareId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProjectSetupV2.Models.Hardwares.Display", b =>
                {
                    b.HasOne("ProjectSetupV2.Models.Hardwares.UserHardware", "UserHardware")
                        .WithMany("Display")
                        .HasForeignKey("UserHardwareId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProjectSetupV2.Models.Hardwares.UsbDevice", b =>
                {
                    b.HasOne("ProjectSetupV2.Models.Hardwares.UserHardware", "UserHardware")
                        .WithMany("UsbDevice")
                        .HasForeignKey("UserHardwareId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProjectSetupV2.Models.Softwares.RunningSoftwares", b =>
                {
                    b.HasOne("ProjectSetupV2.Models.Softwares.UserSoftware", "UserSoftware")
                        .WithMany("RunningSoftwares")
                        .HasForeignKey("MainSoftwareId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
