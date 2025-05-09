using System;
using System.Collections.Generic;
using EmployeeService.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeService.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Dependent> Dependents { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<EmploymentType> EmploymentTypes { get; set; }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<MaritalStatus> MaritalStatuses { get; set; }

    public virtual DbSet<RelationshipType> RelationshipTypes { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=MSI;Database=Enterprise;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Dependent>(entity =>
        {
            entity.ToTable("Dependent");

            entity.Property(e => e.DependentID).ValueGeneratedNever();
            entity.Property(e => e.DateOfBirth).HasColumnType("datetime");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Employee).WithMany(p => p.Dependents)
                .HasForeignKey(d => d.EmployeeID)
                .HasConstraintName("FK_Dependent_Employee");

            entity.HasOne(d => d.RelationshipType).WithMany(p => p.Dependents)
                .HasForeignKey(d => d.RelationshipTypeID)
                .HasConstraintName("FK_Dependent_Dependent");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.ToTable("Employee");

            entity.Property(e => e.EmployeeID).ValueGeneratedNever();
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.HireDate).HasColumnType("datetime");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TerminateDate).HasColumnType("datetime");

            entity.HasOne(d => d.EmploymentType).WithMany(p => p.Employees)
                .HasForeignKey(d => d.EmploymentTypeID)
                .HasConstraintName("FK_Employee_EmploymentType");

            entity.HasOne(d => d.Group).WithMany(p => p.Employees)
                .HasForeignKey(d => d.GroupID)
                .HasConstraintName("FK_Employee_Group");

            entity.HasOne(d => d.MaritalStatus).WithMany(p => p.Employees)
                .HasForeignKey(d => d.MaritalStatusID)
                .HasConstraintName("FK_Employee_MaritalStatus");
        });

        modelBuilder.Entity<EmploymentType>(entity =>
        {
            entity.ToTable("EmploymentType");

            entity.Property(e => e.EmploymentType1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EmploymentType");
        });

        modelBuilder.Entity<Group>(entity =>
        {
            entity.ToTable("Group");

            entity.Property(e => e.GroupID).ValueGeneratedNever();
            entity.Property(e => e.GroupName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<MaritalStatus>(entity =>
        {
            entity.ToTable("MaritalStatus");

            entity.Property(e => e.StatusName).HasMaxLength(50);
        });

        modelBuilder.Entity<RelationshipType>(entity =>
        {
            entity.ToTable("RelationshipType");

            entity.Property(e => e.RelationshipType1)
                .HasMaxLength(50)
                .HasColumnName("RelationshipType");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("User");

            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
