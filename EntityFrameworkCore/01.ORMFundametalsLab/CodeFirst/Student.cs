using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst
{
    public class Student
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public int Age { get; set; }
        public virtual School? School { get; set; }
        public virtual ICollection<Exam> exams { get; } = new List<Exam>();
    }
}
