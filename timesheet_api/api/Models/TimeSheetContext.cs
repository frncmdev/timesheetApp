using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace api.Models
{
    public partial class TimeSheetContext : DbContext
    {
        public TimeSheetContext()
        {
        }

        public TimeSheetContext(DbContextOptions<TimeSheetContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Class> Classes { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<Task> Tasks { get; set; } = null!;
        public virtual DbSet<TaskLine> TaskLines { get; set; } = null!;
        public virtual DbSet<Teacher> Teachers { get; set; } = null!;
        public virtual DbSet<Timesheet> Timesheets { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DOCTOR-SEX;Initial Catalog=TimeSheet;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Class>(entity =>
            {
                entity.ToTable("Class");

                entity.Property(e => e.ClassId)
                    .HasMaxLength(32)
                    .HasColumnName("ClassID");

                entity.Property(e => e.ClassDescription).HasMaxLength(200);

                entity.Property(e => e.ClassName).HasMaxLength(50);

                entity.HasMany(d => d.Students)
                    .WithMany(p => p.Classes)
                    .UsingEntity<Dictionary<string, object>>(
                        "ClassStudentAllocation",
                        l => l.HasOne<Student>().WithMany().HasForeignKey("StudentId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_StudentID_CSA"),
                        r => r.HasOne<Class>().WithMany().HasForeignKey("ClassId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_TIMESHEETID_CSA"),
                        j =>
                        {
                            j.HasKey("ClassId", "StudentId").HasName("PK_CIDSID");

                            j.ToTable("ClassStudentAllocation");

                            j.IndexerProperty<string>("ClassId").HasMaxLength(32).HasColumnName("classID");

                            j.IndexerProperty<int>("StudentId").HasColumnName("StudentID");
                        });
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("student");

                entity.HasIndex(e => e.Salt, "UQ__student__A152BCCE74596C8B")
                    .IsUnique();

                entity.HasIndex(e => e.Email, "UQ__student__A9D105342CA1B94E")
                    .IsUnique();

                entity.Property(e => e.StudentId)
                    .ValueGeneratedNever()
                    .HasColumnName("StudentID");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.Password)
                    .HasMaxLength(64)
                    .HasColumnName("PASSWORD")
                    .IsFixedLength();

                entity.Property(e => e.Salt).HasMaxLength(32);

                entity.Property(e => e.SurName).HasMaxLength(50);
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.ToTable("task");

                entity.Property(e => e.TaskId).HasColumnName("TaskID");

                entity.Property(e => e.TaskDescription)
                    .HasMaxLength(200)
                    .HasColumnName("taskDescription");

                entity.Property(e => e.TaskName)
                    .HasMaxLength(50)
                    .HasColumnName("taskName");
            });

            modelBuilder.Entity<TaskLine>(entity =>
            {
                entity.HasKey(e => new { e.TaskId, e.TimeSheetId })
                    .HasName("PK_TIDTSID");

                entity.ToTable("TaskLine");

                entity.Property(e => e.TaskId).HasColumnName("TaskID");

                entity.Property(e => e.TimeSheetId)
                    .HasMaxLength(32)
                    .HasColumnName("TimeSheetID");

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.TaskLines)
                    .HasForeignKey(d => d.TaskId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TASKID_TL");

                entity.HasOne(d => d.TimeSheet)
                    .WithMany(p => p.TaskLines)
                    .HasForeignKey(d => d.TimeSheetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TIMESHEETID_TL");
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.ToTable("Teacher");

                entity.HasIndex(e => e.Salt, "UQ__Teacher__A152BCCE87280108")
                    .IsUnique();

                entity.HasIndex(e => e.Email, "UQ__Teacher__A9D1053426735072")
                    .IsUnique();

                entity.Property(e => e.TeacherId)
                    .HasMaxLength(32)
                    .HasColumnName("TeacherID");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.Password)
                    .HasMaxLength(64)
                    .HasColumnName("PASSWORD")
                    .IsFixedLength();

                entity.Property(e => e.Salt).HasMaxLength(32);

                entity.Property(e => e.SurName).HasMaxLength(50);

                entity.HasMany(d => d.Classes)
                    .WithMany(p => p.Teachers)
                    .UsingEntity<Dictionary<string, object>>(
                        "TeacherClassAllocation",
                        l => l.HasOne<Class>().WithMany().HasForeignKey("ClassId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_ClassID_TCA"),
                        r => r.HasOne<Teacher>().WithMany().HasForeignKey("TeacherId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_TEACHERID_TCA"),
                        j =>
                        {
                            j.HasKey("TeacherId", "ClassId").HasName("PK_TIDCID");

                            j.ToTable("TeacherClassAllocation");

                            j.IndexerProperty<string>("TeacherId").HasMaxLength(32).HasColumnName("TeacherID");

                            j.IndexerProperty<string>("ClassId").HasMaxLength(32).HasColumnName("classID");
                        });
            });

            modelBuilder.Entity<Timesheet>(entity =>
            {
                entity.ToTable("Timesheet");

                entity.HasIndex(e => e.Email, "UQ__Timeshee__A9D1053433B77011")
                    .IsUnique();

                entity.Property(e => e.TimesheetId)
                    .HasMaxLength(32)
                    .HasColumnName("timesheetID");

                entity.Property(e => e.Checked).HasColumnName("checked");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.IsValid).HasColumnName("isValid");

                entity.Property(e => e.StudentId).HasColumnName("studentID");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Timesheets)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Student");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
