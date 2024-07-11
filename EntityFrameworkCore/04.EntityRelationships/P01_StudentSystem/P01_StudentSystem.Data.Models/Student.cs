using P01_StudentSystem.Common;
using System.ComponentModel.DataAnnotations;

namespace P01_StudentSystem.Data.Models;

public class Student
{
    public Student()
    {
        this.StudentsCourses = new HashSet<StudentCourse>();
        this.Homeworks= new HashSet<Homework>();    
    }

    public int StudentId { get; set; }

    [MaxLength(LengthRestrictions.MaxStudentNameLength)]
    public string Name { get; set;}
    [MaxLength(LengthRestrictions.MaxStudentNameLength)]
    public string? PhoneNumber {  get; set; } 
    public DateTime RegisteredOn { get; set; }
    public DateTime? Birthday { get; set; }

    public virtual ICollection<StudentCourse> StudentsCourses { get; set; }
    public virtual ICollection<Homework> Homeworks { get; set; }
}