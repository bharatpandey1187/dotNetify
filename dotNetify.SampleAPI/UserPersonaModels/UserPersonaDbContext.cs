using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using dotNetify.SampleAPI.UserPersonaModels;

namespace DotNetify.SampleAPI.UserPersonaModels
{
    public partial class UserPersonaDbContext : DbContext
    {
        public UserPersonaDbContext()
        {
        }

        public UserPersonaDbContext(DbContextOptions<UserPersonaDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CandidateRedeployment> CandidateRedeployments { get; set; } = null!;
        public virtual DbSet<CandidateStatus> CandidateStatuses { get; set; } = null!;
        public virtual DbSet<CandidateStatusReason> CandidateStatusReasons { get; set; } = null!;
        public virtual DbSet<CandidateTalentDevelopment> CandidateTalentDevelopments { get; set; } = null!;
        public virtual DbSet<CandidateTransition> CandidateTransitions { get; set; } = null!;
        public virtual DbSet<Colleague> Colleagues { get; set; } = null!;
        public virtual DbSet<CustomerAdmin> CustomerAdmins { get; set; } = null!;
        public virtual DbSet<ForeignCandidateRedeployment> ForeignCandidateRedeployments { get; set; } = null!;
        public virtual DbSet<ForeignPerson> ForeignPersons { get; set; } = null!;
        public virtual DbSet<ForeignUser> ForeignUsers { get; set; } = null!;
        public virtual DbSet<HiringManager> HiringManagers { get; set; } = null!;
        public virtual DbSet<Permission> Permissions { get; set; } = null!;
        public virtual DbSet<PersonaType> PersonaTypes { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<RoleCategory> RoleCategories { get; set; } = null!;
        public virtual DbSet<RolePermission> RolePermissions { get; set; } = null!;
        public virtual DbSet<UserCompany> UserCompanies { get; set; } = null!;
        public virtual DbSet<UserContract> UserContracts { get; set; } = null!;
        public virtual DbSet<UserCountry> UserCountries { get; set; } = null!;
        public virtual DbSet<UserLanguage> UserLanguages { get; set; } = null!;
        public virtual DbSet<UserLegacyInfo> UserLegacyInfos { get; set; } = null!;
        public virtual DbSet<UserRelationshipType> UserRelationshipTypes { get; set; } = null!;
        public virtual DbSet<UserRole> UserRoles { get; set; } = null!;
        public virtual DbSet<UsersRelationshipMapping> UsersRelationshipMappings { get; set; } = null!;
        public virtual DbSet<VAllpersonauser> VAllpersonausers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Server=pdb-nam-eus-compaas-dev.postgres.database.azure.com;Database=COMPaaSUserPersona;Port=5432;User Id=NIITech_Rep;Password=Niit@compaas45db;Ssl Mode=VerifyFull;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("dblink")
                .HasPostgresExtension("hypopg")
                .HasPostgresExtension("postgres_fdw")
                .HasPostgresExtension("uuid-ossp");

            modelBuilder.Entity<CandidateRedeployment>(entity =>
            {
                entity.ToTable("CandidateRedeployment", "personas");

                entity.HasIndex(e => e.StatusReasonId, "FKIdx_CandRed_StatusReason");

                entity.Property(e => e.Id).UseIdentityAlwaysColumn();

                entity.Property(e => e.Active).HasDefaultValueSql("true");

                entity.Property(e => e.CountryExpirationDate).HasColumnType("timestamp without time zone");

                entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");

                entity.Property(e => e.EmployeeId).HasColumnType("character varying");

                entity.Property(e => e.GracePeriodEndDate).HasColumnType("timestamp without time zone");

                entity.Property(e => e.LastUpdatedDate).HasColumnType("timestamp without time zone");

                entity.Property(e => e.ProgramCompletionDate).HasColumnType("timestamp without time zone");

                entity.Property(e => e.ProjectName).HasMaxLength(200);

                entity.Property(e => e.ResumeExpirationDate).HasColumnType("timestamp without time zone");

                entity.HasOne(d => d.StatusReason)
                    .WithMany(p => p.CandidateRedeployments)
                    .HasForeignKey(d => d.StatusReasonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CandRed_StatusReason");
            });

            modelBuilder.Entity<CandidateStatus>(entity =>
            {
                entity.ToTable("CandidateStatus");

                entity.Property(e => e.Id).UseIdentityAlwaysColumn();

                entity.Property(e => e.Active).HasDefaultValueSql("true");

                entity.Property(e => e.LastUpdatedDate).HasColumnType("timestamp without time zone");

                entity.Property(e => e.NameTranslationKey).HasMaxLength(75);

                entity.Property(e => e.Value).HasMaxLength(50);
            });

            modelBuilder.Entity<CandidateStatusReason>(entity =>
            {
                entity.ToTable("CandidateStatusReason");

                entity.HasIndex(e => e.StatusId, "FKIdx_CandStatus_StatusReason");

                entity.Property(e => e.Id).UseIdentityAlwaysColumn();

                entity.Property(e => e.Active).HasDefaultValueSql("true");

                entity.Property(e => e.LastUpdatedDate).HasColumnType("timestamp without time zone");

                entity.Property(e => e.NameTranslationKey).HasMaxLength(75);

                entity.Property(e => e.Reason).HasMaxLength(100);

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.CandidateStatusReasons)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CandStatus_StatusReason");
            });

            modelBuilder.Entity<CandidateTalentDevelopment>(entity =>
            {
                entity.ToTable("CandidateTalentDevelopment", "personas");

                entity.HasIndex(e => e.CandidateStatusReasonId, "FKIdx_CandTalDev_StatusReason");

                entity.Property(e => e.Id).UseIdentityAlwaysColumn();

                entity.Property(e => e.Active).HasDefaultValueSql("true");

                entity.Property(e => e.CountryExpirationDate).HasColumnType("timestamp without time zone");

                entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");

                entity.Property(e => e.EmployeeId).HasMaxLength(50);

                entity.Property(e => e.GracePeriodEndDate).HasColumnType("timestamp without time zone");

                entity.Property(e => e.LastUpdatedDate).HasColumnType("timestamp without time zone");

                entity.Property(e => e.ManagerSalesForceContactId)
                    .HasMaxLength(30)
                    .HasColumnName("ManagerSalesForceContactID");

                entity.Property(e => e.ProgramCompletionDate).HasColumnType("timestamp without time zone");

                entity.Property(e => e.ProjectName).HasMaxLength(200);

                entity.Property(e => e.ResumeExpirationDate).HasColumnType("timestamp without time zone");

                entity.HasOne(d => d.CandidateStatusReason)
                    .WithMany(p => p.CandidateTalentDevelopments)
                    .HasForeignKey(d => d.CandidateStatusReasonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CandTalDev_StatusReason");
            });

            modelBuilder.Entity<CandidateTransition>(entity =>
            {
                entity.ToTable("CandidateTransition", "personas");

                entity.HasIndex(e => e.CandidateStatusReasonId, "fkIdx_CandTran_StatusReasonId");

                entity.Property(e => e.Id).UseIdentityAlwaysColumn();

                entity.Property(e => e.Active).HasDefaultValueSql("true");

                entity.Property(e => e.CountryExpirationDate).HasColumnType("timestamp without time zone");

                entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");

                entity.Property(e => e.EmployeeId).HasMaxLength(50);

                entity.Property(e => e.GracePeriodEndDate).HasColumnType("timestamp without time zone");

                entity.Property(e => e.LastUpdatedDate).HasColumnType("timestamp without time zone");

                entity.Property(e => e.ProgramCompletionDate).HasColumnType("timestamp without time zone");

                entity.Property(e => e.ProjectName).HasMaxLength(200);

                entity.Property(e => e.ResumeExpirationDate).HasColumnType("timestamp without time zone");

                entity.HasOne(d => d.CandidateStatusReason)
                    .WithMany(p => p.CandidateTransitions)
                    .HasForeignKey(d => d.CandidateStatusReasonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CANDTRAN_STATUSREASON");
            });

            modelBuilder.Entity<Colleague>(entity =>
            {
                entity.ToTable("Colleague", "personas");

                entity.Property(e => e.Id).UseIdentityAlwaysColumn();

                entity.Property(e => e.Active).HasDefaultValueSql("true");

                entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");

                entity.Property(e => e.LastUpdatedDate).HasColumnType("timestamp without time zone");

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<CustomerAdmin>(entity =>
            {
                entity.ToTable("CustomerAdmin", "personas");

                entity.Property(e => e.Id).UseIdentityAlwaysColumn();

                entity.Property(e => e.Active).HasDefaultValueSql("true");

                entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");

                entity.Property(e => e.LastUpdatedDate).HasColumnType("timestamp without time zone");
            });

            modelBuilder.Entity<ForeignCandidateRedeployment>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("foreign_candidate_redeployment");
            });

            modelBuilder.Entity<ForeignPerson>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("foreign_persons");
            });

            modelBuilder.Entity<ForeignUser>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("foreign_user");
            });

            modelBuilder.Entity<HiringManager>(entity =>
            {
                entity.ToTable("HiringManager", "personas");

                entity.Property(e => e.Id).UseIdentityAlwaysColumn();

                entity.Property(e => e.Active).HasDefaultValueSql("true");

                entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");

                entity.Property(e => e.LastUpdatedDate).HasColumnType("timestamp without time zone");
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.ToTable("Permission", "colleaguerbac");

                entity.Property(e => e.Id).UseIdentityAlwaysColumn();

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("true");

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<PersonaType>(entity =>
            {
                entity.ToTable("PersonaType");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Active).HasDefaultValueSql("true");

                entity.Property(e => e.Name).HasColumnType("character varying");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role", "colleaguerbac");

                entity.HasIndex(e => e.RoleCategoryId, "FK_RoleCategory_Role");

                entity.Property(e => e.Id).UseIdentityAlwaysColumn();

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("true");

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.RoleCategoryId).HasColumnName("RoleCategoryID");

                entity.HasOne(d => d.RoleCategory)
                    .WithMany(p => p.Roles)
                    .HasForeignKey(d => d.RoleCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoleCategory_Role");
            });

            modelBuilder.Entity<RoleCategory>(entity =>
            {
                entity.ToTable("RoleCategory");

                entity.Property(e => e.Id).UseIdentityAlwaysColumn();

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("true");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<RolePermission>(entity =>
            {
                entity.ToTable("Role_Permission", "colleaguerbac");

                entity.HasIndex(e => e.PermissionId, "FK_Permission_RolePermission");

                entity.HasIndex(e => e.RoleId, "FK_Role_RolePermission");

                entity.Property(e => e.Id).UseIdentityAlwaysColumn();

                entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");

                entity.Property(e => e.LastUpdatedDate).HasColumnType("timestamp without time zone");

                entity.Property(e => e.PermissionId).HasColumnName("PermissionID");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.RolePermissions)
                    .HasForeignKey(d => d.PermissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Permission_RolePermission");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RolePermissions)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Role_RolePermission");
            });

            modelBuilder.Entity<UserCompany>(entity =>
            {
                entity.ToTable("User_Company", "userAccess");

                entity.HasIndex(e => e.UserId, "Idx_UserID");

                entity.Property(e => e.Id).UseIdentityAlwaysColumn();

                entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");

                entity.Property(e => e.LastUpdatedDate).HasColumnType("timestamp without time zone");
            });

            modelBuilder.Entity<UserContract>(entity =>
            {
                entity.ToTable("User_Contract", "userAccess");

                entity.HasIndex(e => e.UserId, "Idx_User_Contract_UserID");

                entity.Property(e => e.Id).UseIdentityAlwaysColumn();

                entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");

                entity.Property(e => e.LastUpdatedDate).HasColumnType("timestamp without time zone");
            });

            modelBuilder.Entity<UserCountry>(entity =>
            {
                entity.ToTable("User_Country", "userAccess");

                entity.HasIndex(e => e.UserId, "Idx_User_Country_UserID");

                entity.Property(e => e.Id).UseIdentityAlwaysColumn();

                entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");

                entity.Property(e => e.LastUpdatedDate).HasColumnType("timestamp without time zone");
            });

            modelBuilder.Entity<UserLanguage>(entity =>
            {
                entity.ToTable("User_Language", "userAccess");

                entity.Property(e => e.Id).UseIdentityAlwaysColumn();

                entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");

                entity.Property(e => e.LastUpdatedDate).HasColumnType("timestamp without time zone");
            });

            modelBuilder.Entity<UserLegacyInfo>(entity =>
            {
                entity.ToTable("UserLegacyInfo", "personas");

                entity.HasIndex(e => e.PersonaTypeId, "fkIdx_UserLegacyInfo_PersonaTypeId");

                entity.Property(e => e.Id).UseIdentityAlwaysColumn();

                entity.Property(e => e.AlternateContact).HasMaxLength(200);

                entity.HasOne(d => d.PersonaType)
                    .WithMany(p => p.UserLegacyInfos)
                    .HasForeignKey(d => d.PersonaTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PersonaType_UserLegacyInfo");
            });

            modelBuilder.Entity<UserRelationshipType>(entity =>
            {
                entity.ToTable("UserRelationshipType");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.ToTable("User_Role", "colleaguerbac");

                entity.HasIndex(e => e.RoleId, "FK_Role_UserRole");

                entity.Property(e => e.Id).UseIdentityAlwaysColumn();

                entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");

                entity.Property(e => e.LastUpdatedDate).HasColumnType("timestamp without time zone");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Role_UserRole");
            });

            modelBuilder.Entity<UsersRelationshipMapping>(entity =>
            {
                entity.ToTable("UsersRelationshipMapping", "personas");

                entity.Property(e => e.Id).UseIdentityAlwaysColumn();

                entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");

                entity.Property(e => e.ExpireDate).HasColumnType("timestamp without time zone");

                entity.Property(e => e.LastUpdatedDate).HasColumnType("timestamp without time zone");

                entity.Property(e => e.StartDate).HasColumnType("timestamp without time zone");

                entity.HasOne(d => d.RelationshipType)
                    .WithMany(p => p.UsersRelationshipMappings)
                    .HasForeignKey(d => d.RelationshipTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserRelationShipMapping_RelationShipType");
            });

            modelBuilder.Entity<VAllpersonauser>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("v_allpersonausers", "personas");

                entity.Property(e => e.ProjectName).HasColumnType("character varying");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
