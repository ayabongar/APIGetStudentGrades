using System.ComponentModel.DataAnnotations;

namespace APIGetStudentGrades.Models
{
    public class StudentGrades
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public int percentage { get; set; }
    }
}
