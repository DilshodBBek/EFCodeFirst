using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCodeFirst.Domain.Models
{
    [Table("student_teacher")]
    public class StudentTeacher
    {
        [Column("student_teacher_id")]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("student_id")]
        public required Student Student { get; set; }
        [Column("teacher_id")]

        public required Teacher Teacher { get; set; }
        [Column("subject_id")]

        public required Subject Subject { get; set; }


        public override string ToString()
        {
            return $"Id:{Id},\n Student:{Student},\n Teacher:{Teacher},\n Subject:{Subject}";
        }
    }
}
