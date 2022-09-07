using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using CarClinicAPI.Repository.Models;

namespace CarClinicAPI.Repository
{
    public partial class CrudOperationDbContext : DbContext
    {
        public CrudOperationDbContext()
        {
        }

        public CrudOperationDbContext(DbContextOptions<CrudOperationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<HrmTbEmployeeInfo> HrmTbEmployeeInfos { get; set; } = null!;
        public virtual DbSet<HrmTbPrmBranch> HrmTbPrmBranches { get; set; } = null!;
        public virtual DbSet<HrmTbPrmDepartment> HrmTbPrmDepartments { get; set; } = null!;
        public virtual DbSet<HrmTbPrmDesignation> HrmTbPrmDesignations { get; set; } = null!;
        public virtual DbSet<InvTbBrandModel> InvTbBrandModels { get; set; } = null!;
        public virtual DbSet<InvTbPartInfo> InvTbPartInfos { get; set; } = null!;
        public virtual DbSet<InvTbPrmEngine> InvTbPrmEngines { get; set; } = null!;
        public virtual DbSet<InvTbPrmVehicleBrand> InvTbPrmVehicleBrands { get; set; } = null!;
        public virtual DbSet<SerTbJobInfo> SerTbJobInfos { get; set; } = null!;
        public virtual DbSet<SerTbJobServiceDiagPart> SerTbJobServiceDiagParts { get; set; } = null!;
        public virtual DbSet<SerTbJobServiceDiagnostic> SerTbJobServiceDiagnostics { get; set; } = null!;
        public virtual DbSet<SerTbOwnerInfo> SerTbOwnerInfos { get; set; } = null!;
        public virtual DbSet<SerTbPrmJobStatus> SerTbPrmJobStatuses { get; set; } = null!;
        public virtual DbSet<SerTbPrmJobTask> SerTbPrmJobTasks { get; set; } = null!;
        public virtual DbSet<SerTbPrmServiceCategory> SerTbPrmServiceCategories { get; set; } = null!;
        public virtual DbSet<SerTbPrmVehicleType> SerTbPrmVehicleTypes { get; set; } = null!;
        public virtual DbSet<SerTbVehicleInfo> SerTbVehicleInfos { get; set; } = null!;
        public virtual DbSet<TbOwnerCategory> TbOwnerCategories { get; set; } = null!;
        public virtual DbSet<TbOwnerType> TbOwnerTypes { get; set; } = null!;
        public virtual DbSet<TbPrmUserInfo> TbPrmUserInfos { get; set; } = null!;
        public virtual DbSet<TbPrmUserRole> TbPrmUserRoles { get; set; } = null!;

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HrmTbEmployeeInfo>(entity =>
            {
                entity.Property(e => e.EmerRelation).IsFixedLength();

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.HrmTbEmployeeInfos)
                    .HasForeignKey(d => d.BranchId)
                    .HasConstraintName("FK_HRM_TB_EmployeeInfo_HRM_TB_PrmBranch");

                entity.HasOne(d => d.Dept)
                    .WithMany(p => p.HrmTbEmployeeInfos)
                    .HasForeignKey(d => d.DeptId)
                    .HasConstraintName("FK_HRM_TB_EmployeeInfo_HRM_TB_PrmDepartment");

                entity.HasOne(d => d.Desg)
                    .WithMany(p => p.HrmTbEmployeeInfos)
                    .HasForeignKey(d => d.DesgId)
                    .HasConstraintName("FK_HRM_TB_EmployeeInfo_HRM_TB_PrmDesignation");
            });

            modelBuilder.Entity<HrmTbPrmDepartment>(entity =>
            {
                entity.HasKey(e => e.DeptId)
                    .HasName("Pk_Department");
            });

            modelBuilder.Entity<InvTbBrandModel>(entity =>
            {
                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.InvTbBrandModels)
                    .HasForeignKey(d => d.BrandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_INV_TB_BrandModel_INV_TB_PrmVehicleBrand");
            });

            modelBuilder.Entity<InvTbPartInfo>(entity =>
            {
                entity.Property(e => e.PartId).ValueGeneratedOnAdd();

                entity.Property(e => e.Active).HasDefaultValueSql("((1))");

                entity.Property(e => e.PartType).HasComment("It will hold Paint/Local/Oil/Imported");

                entity.HasOne(d => d.Engine)
                    .WithMany(p => p.InvTbPartInfos)
                    .HasForeignKey(d => d.EngineId)
                    .HasConstraintName("FK_INV_TB_PartInfo_INV_TB_PrmEngine");

                entity.HasOne(d => d.Model)
                    .WithMany(p => p.InvTbPartInfos)
                    .HasForeignKey(d => d.ModelId)
                    .HasConstraintName("FK_INV_TB_PartInfo_INV_TB_BrandModel");
            });

            modelBuilder.Entity<SerTbJobInfo>(entity =>
            {
                entity.HasKey(e => e.JobId)
                    .HasName("pk_JobInfo");

                entity.Property(e => e.JobClosedOn).HasComment("When gate pass generated, this time will be recorded as Job Closed date");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.SerTbJobInfos)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK_SER_TB_JobInfo_TB_PrmUserInfo");

                entity.HasOne(d => d.JobStatus)
                    .WithMany(p => p.SerTbJobInfos)
                    .HasForeignKey(d => d.JobStatusId)
                    .HasConstraintName("fk_JobInfoJobStatus");
            });

            modelBuilder.Entity<SerTbJobServiceDiagPart>(entity =>
            {
                entity.Property(e => e.Booked).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsEstimated).HasDefaultValueSql("((0))");

                entity.Property(e => e.Picked).HasDefaultValueSql("((0))");

                entity.Property(e => e.Tstamp)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.SerTbJobServiceDiagParts)
                    .HasForeignKey(d => d.JobId)
                    .HasConstraintName("FK_SER_TB_JobServiceDiagParts_SER_TB_JobInfo");

                entity.HasOne(d => d.Part)
                    .WithMany(p => p.SerTbJobServiceDiagParts)
                    .HasForeignKey(d => d.PartId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SER_TB_JobServiceDiagParts_INV_TB_PartInfo");
            });

            modelBuilder.Entity<SerTbJobServiceDiagnostic>(entity =>
            {
                entity.Property(e => e.IsApproved).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsForEstimation).HasDefaultValueSql("((1))");

                entity.Property(e => e.TaskRemarks).IsSparse();

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.SerTbJobServiceDiagnostics)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SER_TB_JobServiceDiagnostic_TB_PrmUserInfo");

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.SerTbJobServiceDiagnostics)
                    .HasForeignKey(d => d.JobId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_JobServiceDiagnosticJob");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.SerTbJobServiceDiagnostics)
                    .HasForeignKey(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SER_TB_JobServiceDiagnostic_SER_TB_PrmJobTask");
            });

            modelBuilder.Entity<SerTbOwnerInfo>(entity =>
            {
                entity.HasOne(d => d.Category)
                    .WithMany(p => p.SerTbOwnerInfos)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_SER_TB_OwnerInfo_SER_PrmCategory");

                entity.HasOne(d => d.OwnerType)
                    .WithMany(p => p.SerTbOwnerInfos)
                    .HasForeignKey(d => d.OwnerTypeId)
                    .HasConstraintName("FK_SER_TB_OwnerInfo_TB_OwnerType");
            });

            modelBuilder.Entity<SerTbPrmJobTask>(entity =>
            {
                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.SerTbPrmJobTasks)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("FK_SER_TB_PrmJobTask_SER_TB_PrmServiceCategory");
            });

            modelBuilder.Entity<SerTbPrmServiceCategory>(entity =>
            {
                entity.HasKey(e => e.CategoryId)
                    .HasName("PK_SER_TB_PrmServiceCatagory");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("FK_SER_TB_PrmServiceCategory_SER_TB_PrmServiceCategory");
            });

            modelBuilder.Entity<SerTbVehicleInfo>(entity =>
            {
                entity.HasKey(e => e.VehInfoId)
                    .HasName("pk_VehicleInfo");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.SerTbVehicleInfos)
                    .HasForeignKey(d => d.BrandId)
                    .HasConstraintName("fk_VehicleInfoBrand");

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.SerTbVehicleInfos)
                    .HasForeignKey(d => d.OwnerId)
                    .HasConstraintName("fk_VehicleInfoOwner");

                entity.HasOne(d => d.VehicleType)
                    .WithMany(p => p.SerTbVehicleInfos)
                    .HasForeignKey(d => d.VehicleTypeId)
                    .HasConstraintName("fk_VehicleInfoVehicleType");
            });

            modelBuilder.Entity<TbOwnerCategory>(entity =>
            {
                entity.HasOne(d => d.OwnerType)
                    .WithMany(p => p.TbOwnerCategories)
                    .HasForeignKey(d => d.OwnerTypeId)
                    .HasConstraintName("FK_TB_Owner_Category");
            });

            modelBuilder.Entity<TbOwnerType>(entity =>
            {
                entity.HasKey(e => e.OwnerTypeId)
                    .HasName("PK_SER_TB_PrmOwnerType");
            });

            modelBuilder.Entity<TbPrmUserInfo>(entity =>
            {
                entity.HasOne(d => d.EmpAuto)
                    .WithMany(p => p.TbPrmUserInfos)
                    .HasForeignKey(d => d.EmpAutoId)
                    .HasConstraintName("FK_TB_PrmUserInfo_HRM_TB_EmployeeInfo");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.TbPrmUserInfos)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_TB_PrmUserInfo_TB_PrmUserInfo");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
