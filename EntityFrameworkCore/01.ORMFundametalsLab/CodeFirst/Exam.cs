using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst
{
    public class Exam
    {
        public int ExamId { get; set; }

        [MaxLength(20)]
        [Required]
        public string Name { get; set; }
        [MaxLength(20)]
        [Required]
        public string Result { get; set; }


        public virtual ICollection<Student> Students { get; } = new List<Student>();
    }
}
