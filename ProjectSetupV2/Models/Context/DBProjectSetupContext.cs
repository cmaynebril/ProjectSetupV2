using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ProjectSetupV2.Models.Context;
using ProjectSetupV2.Models.Hardwares;
using ProjectSetupV2.Models.Softwares;

namespace ProjectSetupV2.Models.Context
{
    public partial class DBProjectSetupContext : IdentityDbContext<User, UserRole, int>

    {
        //public DBProjectSetupContext()
        //{
        //}

        public DBProjectSetupContext(DbContextOptions<DBProjectSetupContext> options)
            : base(options)
        {

        }

        public virtual DbSet<BusinessValues> BusinessValues { get; set; }
        public virtual DbSet<Clients> Clients { get; set; }
        public virtual DbSet<Jobs> Jobs { get; set; }
        public virtual DbSet<Assignees> Assignees { get; set; }
        public virtual DbSet<Tasks> Tasks { get; set; }
        public virtual DbSet<JobStatus> JobStatus { get; set; }
        public virtual DbSet<TasksStatus> TasksStatus { get; set; }
        public virtual DbSet<TimesheetsStatus> TimesheetsStatus { get; set; }
        public virtual DbSet<InvoiceType> InvoiceType { get; set; }
        public virtual DbSet<JobTasks> JobTasks { get; set; }
        public virtual DbSet<TaskTimesheet> TaskTimesheet { get; set; }
        public virtual DbSet<Leave> Leave { get; set; }
        public virtual DbSet<LeaveApprover> LeaveApprover { get; set; }
        public virtual DbSet<TypesOfLeave> TypesOfLeave { get; set; }

        public virtual DbSet<Disk> Disk { get; set; }
        public virtual DbSet<Display> Display { get; set; }
        public virtual DbSet<UsbDevice> UsbDevice { get; set; }
        public virtual DbSet<UserHardware> UserHardware { get; set; }
        public virtual DbSet<UserSoftware> UserSoftware { get; set; }



        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("Server=.;Database=DBProjectSetup;Trusted_Connection=True;");
        //    }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.HasAnnotation("ProductVersion", "2.2.3-servicing-35854");

            //modelBuilder.Entity<BusinessValues>(entity =>
            //{
            //    entity.Property(e => e.Business)
            //        .IsRequired()
            //        .HasColumnName("business")
            //        .HasColumnType("text");

            //    entity.Property(e => e.Rate).HasColumnName("rate");
            //});

            //modelBuilder.Entity<Clients>(entity =>
            //{
            //    entity.Property(e => e.Client)
            //        .IsRequired()
            //        .HasColumnName("client")
            //        .HasColumnType("text");
            //});

            //modelBuilder.Entity<Jobs>(entity =>
            //{
            //    entity.Property(e => e.ClientName).HasColumnType("text");

            //    entity.Property(e => e.Job)
            //        .HasColumnName("job")
            //        .HasColumnType("text");

            //    entity.HasOne(d => d.Client)
            //        .WithMany(p => p.Jobs)
            //        .HasForeignKey(d => d.ClientId)
            //        .HasConstraintName("FK__Projects__Custom__398D8EEE");
            //});

            //modelBuilder.Entity<Tasks>(entity =>
            //{
            //    entity.Property(e => e.JobId).HasColumnName("jobId");

            //    entity.Property(e => e.Task)
            //        .HasColumnName("task")
            //        .HasColumnType("text");

            //    entity.HasOne(d => d.BusinessValues)
            //        .WithMany(p => p.Tasks)
            //        .HasForeignKey(d => d.BusinessValuesId)
            //        .HasConstraintName("FK__Tasks__Id__3F466844");

            //    entity.HasOne(d => d.Job)
            //        .WithMany(p => p.Tasks)
            //        .HasForeignKey(d => d.JobId)
            //        .HasConstraintName("FK__Tasks__Id__3E52440B");
            //});
        }



        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("Server=.;Database=DBProjectSetup;Trusted_Connection=True;");
        //    }
        //}

        //public DbSet<ProjectSetupV2.Models.Hardwares.UserHardware> UserHardware { get; set; }


    }
}
