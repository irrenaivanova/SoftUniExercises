using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CodeFirst
{
    public class CodeFirstContext : DbContext
    {
        public virtual DbSet<Exam> Exams { get; set; }
        public virtual DbSet<School> Schools { get; set; }
        public virtual DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("Server=.;Integrated Security=true;" +
                "Database=CodeFirst2024;TrustServerCertificate=True;");

    }
}
