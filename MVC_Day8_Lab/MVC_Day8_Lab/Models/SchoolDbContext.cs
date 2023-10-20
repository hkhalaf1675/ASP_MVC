using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MVC_Day8_Lab.Models;

public partial class SchoolDbContext : DbContext
{
    public SchoolDbContext()
    {
    }

    public SchoolDbContext(DbContextOptions<SchoolDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Instructor> Instructors { get; set; }

    public virtual DbSet<MigrationHistory> MigrationHistories { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<StudentCourseGrade> StudentCourseGrades { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=.;Database=SchoolDB;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PK_dbo.Courses");

            entity.Property(e => e.Code).HasMaxLength(5);
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.Departments");

            entity.HasIndex(e => e.ManagerId, "IX_Manager_ID");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.HiringDate).HasColumnType("datetime");
            entity.Property(e => e.ManagerId).HasColumnName("Manager_ID");

            entity.HasOne(d => d.Manager).WithMany(p => p.Departments)
                .HasForeignKey(d => d.ManagerId)
                .HasConstraintName("FK_dbo.Departments_dbo.Instructors_Manager_ID");
        });

        modelBuilder.Entity<Instructor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.Instructors");

            entity.HasIndex(e => e.DepartmentId, "IX_Department_ID");

            entity.HasIndex(e => e.DepartmentId1, "IX_Department_ID1");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DepartmentId).HasColumnName("Department_ID");
            entity.Property(e => e.DepartmentId1).HasColumnName("Department_ID1");

            entity.HasOne(d => d.Department).WithMany(p => p.InstructorDepartments)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK_dbo.Instructors_dbo.Departments_Department_ID");

            entity.HasOne(d => d.DepartmentId1Navigation).WithMany(p => p.InstructorDepartmentId1Navigations)
                .HasForeignKey(d => d.DepartmentId1)
                .HasConstraintName("FK_dbo.Instructors_dbo.Departments_Department_ID1");

            entity.HasMany(d => d.CourseCodes).WithMany(p => p.Instructors)
                .UsingEntity<Dictionary<string, object>>(
                    "InstructorCourse",
                    r => r.HasOne<Course>().WithMany()
                        .HasForeignKey("CourseCode")
                        .HasConstraintName("FK_dbo.InstructorCourses_dbo.Courses_Course_Code"),
                    l => l.HasOne<Instructor>().WithMany()
                        .HasForeignKey("InstructorId")
                        .HasConstraintName("FK_dbo.InstructorCourses_dbo.Instructors_Instructor_ID"),
                    j =>
                    {
                        j.HasKey("InstructorId", "CourseCode").HasName("PK_dbo.InstructorCourses");
                        j.ToTable("InstructorCourses");
                        j.HasIndex(new[] { "CourseCode" }, "IX_Course_Code");
                        j.HasIndex(new[] { "InstructorId" }, "IX_Instructor_ID");
                        j.IndexerProperty<int>("InstructorId").HasColumnName("Instructor_ID");
                        j.IndexerProperty<string>("CourseCode")
                            .HasMaxLength(5)
                            .HasColumnName("Course_Code");
                    });
        });

        modelBuilder.Entity<MigrationHistory>(entity =>
        {
            entity.HasKey(e => new { e.MigrationId, e.ContextKey }).HasName("PK_dbo.__MigrationHistory");

            entity.ToTable("__MigrationHistory");

            entity.Property(e => e.MigrationId).HasMaxLength(150);
            entity.Property(e => e.ContextKey).HasMaxLength(300);
            entity.Property(e => e.ProductVersion).HasMaxLength(32);
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.Students");

            entity.Property(e => e.BirthDate).HasColumnType("datetime");
            entity.Property(e => e.Fname).HasColumnName("FName");
            entity.Property(e => e.Lname).HasColumnName("LName");
        });

        modelBuilder.Entity<StudentCourseGrade>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.Student_Course_Grade");

            entity.ToTable("Student_Course_Grade");

            entity.HasIndex(e => e.CourseCode, "IX_Course_Code");

            entity.HasIndex(e => e.StudentId, "IX_Student_Id");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CourseCode)
                .HasMaxLength(5)
                .HasColumnName("Course_Code");
            entity.Property(e => e.StudentId).HasColumnName("Student_Id");

            entity.HasOne(d => d.CourseCodeNavigation).WithMany(p => p.StudentCourseGrades)
                .HasForeignKey(d => d.CourseCode)
                .HasConstraintName("FK_dbo.Student_Course_Grade_dbo.Courses_Course_Code");

            entity.HasOne(d => d.Student).WithMany(p => p.StudentCourseGrades)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK_dbo.Student_Course_Grade_dbo.Students_Student_Id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
