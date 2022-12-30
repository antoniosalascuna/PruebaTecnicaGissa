using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PruebaTecnicaGissa.Models;

public partial class TestDbContext : DbContext
{
    public TestDbContext()
    {
    }

    public TestDbContext(DbContextOptions<TestDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TestContact> TestContacts { get; set; }

    public virtual DbSet<TestHability> TestHabilities { get; set; }

    public virtual DbSet<TestUser> TestUsers { get; set; }

 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TestContact>(entity =>
        {
            entity.HasKey(e => e.TelPrimaryId).HasName("PK__test_con__857F8ECB91E9CD5E");

            entity.ToTable("test_contact");

            entity.Property(e => e.TelPrimaryId).HasColumnName("TEL_PRIMARY_ID");
            entity.Property(e => e.TelNumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("TEL_Number");
            entity.Property(e => e.TelState)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("TEL_State");
            entity.Property(e => e.TelType)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("TEL_Type");
            entity.Property(e => e.UserPrimaryId).HasColumnName("USER_Primary_ID");

            entity.HasOne(d => d.UserPrimary).WithMany(p => p.TestContacts)
                .HasForeignKey(d => d.UserPrimaryId)
                .HasConstraintName("FK_UserID");
        });

        modelBuilder.Entity<TestHability>(entity =>
        {
            entity.HasKey(e => e.HabPrimaryId).HasName("PK__test_hab__DC4DD20056CAB07B");

            entity.ToTable("test_habilities");

            entity.Property(e => e.HabPrimaryId).HasColumnName("HAB_PRIMARY_ID");
            entity.Property(e => e.HabDescripcion)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("HAB_Descripcion");
            entity.Property(e => e.HabName)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("HAB_Name");
            entity.Property(e => e.UserPrimaryId).HasColumnName("USER_Primary_ID");

            entity.HasOne(d => d.UserPrimary).WithMany(p => p.TestHabilities)
                .HasForeignKey(d => d.UserPrimaryId)
                .HasConstraintName("FK_UserID_Habilities");
        });

        modelBuilder.Entity<TestUser>(entity =>
        {
            entity.HasKey(e => e.UserPrimaryId).HasName("PK__test_use__C72DE3E646F0280D");

            entity.ToTable("test_user");

            entity.Property(e => e.UserPrimaryId).HasColumnName("USER_Primary_ID");
            entity.Property(e => e.UserCed)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("USER_Ced");
            entity.Property(e => e.UserEmail)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("USER_Email");
            entity.Property(e => e.UserLastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("USER_LastName");
            entity.Property(e => e.UserNickName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("USER_NickName");
            entity.Property(e => e.UserPass)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("USER_Pass");
            entity.Property(e => e.UserTypeCed)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("USER_Type_Ced");
            entity.Property(e => e.UserUserType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("USER_UserType");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
