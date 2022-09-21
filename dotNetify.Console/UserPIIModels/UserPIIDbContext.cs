using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using dotNetify.Console.EDMX;

namespace DotNetify.Console.EDMX
{
    public partial class UserPIIDbContext : DbContext
    {
        public UserPIIDbContext()
        {
        }

        public UserPIIDbContext(DbContextOptions<UserPIIDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; } = null!;
        public virtual DbSet<AlternateLanguage> AlternateLanguages { get; set; } = null!;
        public virtual DbSet<Email> Emails { get; set; } = null!;
        public virtual DbSet<GenderType> GenderTypes { get; set; } = null!;
        public virtual DbSet<Image> Images { get; set; } = null!;
        public virtual DbSet<MvUser> MvUsers { get; set; } = null!;
        public virtual DbSet<MvUserscontactinfo> MvUserscontactinfos { get; set; } = null!;
        public virtual DbSet<Phone> Phones { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserAddressType> UserAddressTypes { get; set; } = null!;
        public virtual DbSet<UserEmailType> UserEmailTypes { get; set; } = null!;
        public virtual DbSet<UserPersonaSummary> UserPersonaSummaries { get; set; } = null!;
        public virtual DbSet<UserPhoneType> UserPhoneTypes { get; set; } = null!;
        public virtual DbSet<UserWebsiteType> UserWebsiteTypes { get; set; } = null!;
        public virtual DbSet<VDblinkAllpersonauser> VDblinkAllpersonausers { get; set; } = null!;
        public virtual DbSet<VOrdereduseremail> VOrdereduseremails { get; set; } = null!;
        public virtual DbSet<VUsermobile> VUsermobiles { get; set; } = null!;
        public virtual DbSet<Website> Websites { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Server=pdb-nam-eus-compaas-dev.postgres.database.azure.com;Database=COMPaaSUserPII;Port=5432;User Id=NIITech_Rep;Password=Niit@compaas45db;Ssl Mode=VerifyFull;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("dblink");

            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("Address", "users");

                entity.HasIndex(e => e.UserId, "fkIdx_Address_UserID");

                entity.Property(e => e.Id).UseIdentityAlwaysColumn();

                entity.Property(e => e.Active).HasDefaultValueSql("true");

                entity.Property(e => e.City).HasMaxLength(120);

                entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");

                entity.Property(e => e.LastUpdatedDate).HasColumnType("timestamp without time zone");

                entity.Property(e => e.Latitude).HasPrecision(11, 8);

                entity.Property(e => e.Longitude).HasPrecision(11, 8);

                entity.Property(e => e.PostalCode).HasMaxLength(50);

                entity.Property(e => e.StateProvince).HasMaxLength(100);

                entity.Property(e => e.StreetAddress1).HasMaxLength(300);

                entity.Property(e => e.StreetAddress2).HasMaxLength(300);

                entity.HasOne(d => d.UserAddressType)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.UserAddressTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ADDRESS_USERADDRESSTYPE");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USER_ADDRESS");
            });

            modelBuilder.Entity<AlternateLanguage>(entity =>
            {
                entity.ToTable("AlternateLanguages", "users");

                entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            });

            modelBuilder.Entity<Email>(entity =>
            {
                entity.ToTable("Email", "users");

                entity.HasIndex(e => e.UserId, "fkIdx_Email_UserID");

                entity.Property(e => e.Id).UseIdentityAlwaysColumn();

                entity.Property(e => e.Active).HasDefaultValueSql("true");

                entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");

                entity.Property(e => e.LastUpdatedDate).HasColumnType("timestamp without time zone");

                entity.Property(e => e.Value).HasMaxLength(512);

                entity.HasOne(d => d.UserEmailType)
                    .WithMany(p => p.Emails)
                    .HasForeignKey(d => d.UserEmailTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EMAIL_USEREMAILTYPE");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Emails)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USER_EMAIL");
            });

            modelBuilder.Entity<GenderType>(entity =>
            {
                entity.ToTable("GenderType");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("true");

                entity.Property(e => e.Name).HasColumnType("character varying");

                entity.Property(e => e.NameTranslationKey).HasMaxLength(75);
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.ToTable("Images", "users");

                entity.HasIndex(e => e.UserId, "FKIdx_User_Images");

                entity.Property(e => e.Id).UseIdentityAlwaysColumn();

                entity.Property(e => e.Active).HasDefaultValueSql("true");

                entity.Property(e => e.ProfileImageUrl).HasMaxLength(512);

                entity.Property(e => e.ProfileThumbImageUrl).HasMaxLength(512);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Images)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Images");
            });

            modelBuilder.Entity<MvUser>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("mv_Users", "users");

                entity.Property(e => e.Email)
                    .HasMaxLength(512)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName).HasMaxLength(200);

                entity.Property(e => e.LastName).HasMaxLength(200);

                entity.Property(e => e.MiddleName).HasMaxLength(200);

                entity.Property(e => e.Nickname).HasMaxLength(200);

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .HasColumnName("phone");
            });

            modelBuilder.Entity<MvUserscontactinfo>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("mv_userscontactinfo", "users");

                entity.Property(e => e.Email)
                    .HasMaxLength(512)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName).HasMaxLength(200);

                entity.Property(e => e.LastName).HasMaxLength(200);

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .HasColumnName("phone");
            });

            modelBuilder.Entity<Phone>(entity =>
            {
                entity.ToTable("Phone", "users");

                entity.HasIndex(e => e.UserId, "fkIdx_Phone_UserId");

                entity.Property(e => e.Id).UseIdentityAlwaysColumn();

                entity.Property(e => e.Active).HasDefaultValueSql("true");

                entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");

                entity.Property(e => e.LastUpdatedDate).HasColumnType("timestamp without time zone");

                entity.Property(e => e.Value).HasMaxLength(50);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Phones)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USER_PHONE");

                entity.HasOne(d => d.UserPhoneType)
                    .WithMany(p => p.Phones)
                    .HasForeignKey(d => d.UserPhoneTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PHONE_USERPHONETYPE");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User", "users");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");

                entity.Property(e => e.DateMasked).HasColumnType("timestamp without time zone");

                entity.Property(e => e.FirstName).HasMaxLength(200);

                entity.Property(e => e.LastName).HasMaxLength(200);

                entity.Property(e => e.LastUpdatedDate).HasColumnType("timestamp without time zone");

                entity.Property(e => e.MiddleName).HasMaxLength(200);

                entity.Property(e => e.Nickname).HasMaxLength(200);

                entity.HasOne(d => d.GenderNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.Gender)
                    .HasConstraintName("FK_User_GenderType");
            });

            modelBuilder.Entity<UserAddressType>(entity =>
            {
                entity.ToTable("UserAddressType");

                entity.Property(e => e.Id).UseIdentityAlwaysColumn();

                entity.Property(e => e.Active).HasDefaultValueSql("true");

                entity.Property(e => e.Name).HasMaxLength(150);

                entity.Property(e => e.NameTranslationKey).HasMaxLength(75);
            });

            modelBuilder.Entity<UserEmailType>(entity =>
            {
                entity.ToTable("UserEmailType");

                entity.Property(e => e.Id).UseIdentityAlwaysColumn();

                entity.Property(e => e.Active).HasDefaultValueSql("true");

                entity.Property(e => e.Name).HasMaxLength(150);

                entity.Property(e => e.NameTranslationKey).HasMaxLength(75);
            });

            modelBuilder.Entity<UserPersonaSummary>(entity =>
            {
                entity.ToTable("UserPersonaSummary", "users");

                entity.Property(e => e.Id).UseIdentityAlwaysColumn();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserPersonaSummaries)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USER_USERPERSONASUMMARY");
            });

            modelBuilder.Entity<UserPhoneType>(entity =>
            {
                entity.ToTable("UserPhoneType");

                entity.Property(e => e.Id).UseIdentityAlwaysColumn();

                entity.Property(e => e.Active).HasDefaultValueSql("true");

                entity.Property(e => e.Name).HasMaxLength(150);

                entity.Property(e => e.NameTranslationKey).HasMaxLength(75);
            });

            modelBuilder.Entity<UserWebsiteType>(entity =>
            {
                entity.ToTable("UserWebsiteType");

                entity.Property(e => e.Id).UseIdentityAlwaysColumn();

                entity.Property(e => e.Active).HasDefaultValueSql("true");

                entity.Property(e => e.Name).HasMaxLength(150);

                entity.Property(e => e.NameTranslationKey).HasMaxLength(75);
            });

            modelBuilder.Entity<VDblinkAllpersonauser>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("v_dblink_allpersonausers", "users");
            });

            modelBuilder.Entity<VOrdereduseremail>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("v_ordereduseremail", "users");

                entity.Property(e => e.Value).HasMaxLength(512);
            });

            modelBuilder.Entity<VUsermobile>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("v_usermobile", "users");

                entity.Property(e => e.Value).HasMaxLength(50);
            });

            modelBuilder.Entity<Website>(entity =>
            {
                entity.ToTable("Website", "users");

                entity.HasIndex(e => e.UserId, "FKIdx_Website_User");

                entity.HasIndex(e => e.WebsiteTypeId, "FKIdx_Website_WebsiteType");

                entity.Property(e => e.Id).UseIdentityAlwaysColumn();

                entity.Property(e => e.Active).HasDefaultValueSql("true");

                entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");

                entity.Property(e => e.LastUpdatedDate).HasColumnType("timestamp without time zone");

                entity.Property(e => e.Value).HasMaxLength(400);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Websites)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Website_User");

                entity.HasOne(d => d.WebsiteType)
                    .WithMany(p => p.Websites)
                    .HasForeignKey(d => d.WebsiteTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Website_WebsiteType");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
