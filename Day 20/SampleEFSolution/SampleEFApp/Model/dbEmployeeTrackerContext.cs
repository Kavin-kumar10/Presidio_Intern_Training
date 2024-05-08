using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SampleEFApp.Model
{
    public partial class dbEmployeeTrackerContext : DbContext
    {
        public dbEmployeeTrackerContext()
        {
        }

        public dbEmployeeTrackerContext(DbContextOptions<dbEmployeeTrackerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Area> Areas { get; set; } = null!;
        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<Emp> Emps { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<EmployeeSkill> EmployeeSkills { get; set; } = null!;
        public virtual DbSet<Item> Items { get; set; } = null!;
        public virtual DbSet<Sale> Sales { get; set; } = null!;
        public virtual DbSet<Skill> Skills { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=CB66JX3\\DEMOINSTANCE;Initial Catalog=dbEmployeeTracker;Integrated Security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Area>(entity =>
            {
                entity.HasKey(e => e.Area1)
                    .HasName("pk_Areas");

                entity.Property(e => e.Area1)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Area");

                entity.Property(e => e.Zipcode)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.Deptname)
                    .HasName("pk_DEPARTMENT");

                entity.ToTable("DEPARTMENT");

                entity.Property(e => e.Deptname)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("deptname");

                entity.Property(e => e.Bossno).HasColumnName("bossno");

                entity.Property(e => e.Floor)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("floor");

                entity.Property(e => e.Phone)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.HasOne(d => d.BossnoNavigation)
                    .WithMany(p => p.Departments)
                    .HasForeignKey(d => d.Bossno)
                    .HasConstraintName("fk_EMP");
            });

            modelBuilder.Entity<Emp>(entity =>
            {
                entity.HasKey(e => e.Empno)
                    .HasName("pk_EMP");

                entity.ToTable("EMP");

                entity.Property(e => e.Empno).HasColumnName("empno");

                entity.Property(e => e.Deptname)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("deptname");

                entity.Property(e => e.Empname)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("empname");

                entity.Property(e => e.Salary)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("salary");

                entity.HasOne(d => d.DeptnameNavigation)
                    .WithMany(p => p.Emps)
                    .HasForeignKey(d => d.Deptname)
                    .HasConstraintName("fk_Department");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DateOfBirth).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.EmployeeArea)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Phone)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.EmployeeAreaNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.EmployeeArea)
                    .HasConstraintName("fk_Area");
            });

            modelBuilder.Entity<EmployeeSkill>(entity =>
            {
                entity.HasKey(e => new { e.EmployeeId, e.Skill })
                    .HasName("pk_employee_skill");

                entity.ToTable("EmployeeSkill");

                entity.Property(e => e.EmployeeId).HasColumnName("Employee_id");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeSkills)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_skill_eid");

                entity.HasOne(d => d.SkillNavigation)
                    .WithMany(p => p.EmployeeSkills)
                    .HasForeignKey(d => d.Skill)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_skill_EmpSkill");
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.HasKey(e => e.Itemname)
                    .HasName("pk_ITEM");

                entity.ToTable("ITEM");

                entity.Property(e => e.Itemname)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("itemname");

                entity.Property(e => e.Itemcolor)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("itemcolor");

                entity.Property(e => e.Itemtype)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("itemtype");
            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.HasKey(e => e.Salesno)
                    .HasName("pk_SALES");

                entity.ToTable("SALES");

                entity.Property(e => e.Salesno).HasColumnName("salesno");

                entity.Property(e => e.Deptname)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("deptname");

                entity.Property(e => e.Itemname)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("itemname");

                entity.Property(e => e.Saleqty).HasColumnName("saleqty");

                entity.HasOne(d => d.DeptnameNavigation)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.Deptname)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_DEPARTMENT_SALES");

                entity.HasOne(d => d.ItemnameNavigation)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.Itemname)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ITEM_SALES");
            });

            modelBuilder.Entity<Skill>(entity =>
            {
                entity.Property(e => e.SkillId).HasColumnName("Skill_id");

                entity.Property(e => e.Skill1)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Skill");

                entity.Property(e => e.SkillDescription)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
