using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Phase3EndProject.Models
{
    public partial class EmployeesDbContext : DbContext
    {
        public EmployeesDbContext()
        {
        }

        public EmployeesDbContext(DbContextOptions<EmployeesDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DeptMaster> DeptMasters { get; set; } = null!;
        public virtual DbSet<EmpProfile> EmpProfiles { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=(localdb)\\mssqllocaldb;database=EmployeesDb;trusted_connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DeptMaster>(entity =>
            {
                entity.HasKey(e => e.DeptCode)
                    .HasName("PK__DeptMast__BB9B9551408F441E");

                entity.ToTable("DeptMaster");

                entity.HasIndex(e => e.DeptName, "UQ__DeptMast__5E5082653FAA3CC4")
                    .IsUnique();

                entity.Property(e => e.DeptCode).ValueGeneratedNever();

                entity.Property(e => e.DeptName).HasMaxLength(50);
            });

            modelBuilder.Entity<EmpProfile>(entity =>
            {
                entity.HasKey(e => e.EmpCode)
                    .HasName("PK__EmpProfi__7DA847CB7127566E");

                entity.ToTable("EmpProfile");

                entity.Property(e => e.EmpCode).ValueGeneratedNever();

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.Edept).HasColumnName("EDept");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.EmpName).HasMaxLength(50);

                entity.HasOne(d => d.EdeptNavigation)
                    .WithMany(p => p.EmpProfiles)
                    .HasForeignKey(d => d.Edept)
                    .HasConstraintName("FK__EmpProfil__EDept__4CA06362");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
