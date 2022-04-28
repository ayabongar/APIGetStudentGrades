#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using APIGetStudentGrades.Models;

namespace APIGetStudentGrades.Data
{
    public class APIGetStudentGradesContext : DbContext
    {
        public APIGetStudentGradesContext (DbContextOptions<APIGetStudentGradesContext> options)
            : base(options)
        {
        }

        public DbSet<APIGetStudentGrades.Models.StudentGrades> StudentGrades { get; set; }
    }
}
