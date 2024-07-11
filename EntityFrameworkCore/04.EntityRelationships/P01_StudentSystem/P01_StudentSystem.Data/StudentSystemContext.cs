using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Common;
using P01_StudentSystem.Data.Models;

namespace P01_StudentSystem.Data;

public class StudentSystemContext : DbContext
{
    public StudentSystemContext()
    {
    }
    public StudentSystemContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Student> Students { get; set; }
    public DbSet<Homework> Homeworks { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<StudentCourse> StudentsCourses { get; set; }
    public DbSet<Resource> Resources { get; set; }



    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured) 
        {
            optionsBuilder.UseSqlServer(DbConfig.ConnectionString);
        }
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Resource>()
            .Property(x => x.Url)
            .HasColumnType("varchar(max)");
            


        modelBuilder.Entity<Student>()
            .Property(x => x.PhoneNumber)
            .HasColumnType("char(10)")
            .IsFixedLength(true)
            .HasMaxLength(10);
            


        modelBuilder.Entity<StudentCourse>()
            .HasKey(x => new { x.StudentId, x.CourseId });

   
        base.OnModelCreating(modelBuilder);
    }
}