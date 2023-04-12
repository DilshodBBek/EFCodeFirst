using EFCodeFirst.Domain.States;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCodeFirst.Domain.Models
{
    [Table("grade")]
    public class Grade
    {
        [Column("grade_id")]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GradeId { get; set; }
        [Column("student_teacher_id")]

        public required StudentTeacher StudentTeacher { get; set; }

        [Column("grade_enum")]
        public GradeEnum GradeEnum { get; set; }

        [Column("grade_date")]
        public DateTime Date { get; set; }
        public override string ToString()
        {
            return $"GradeId:{GradeId},\n StudentTeacher:{StudentTeacher},\n GradeEnum:{GradeEnum},\n Date:{Date}";
        }
    }
}
