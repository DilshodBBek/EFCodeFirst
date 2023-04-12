using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCodeFirst.Domain.Models
{
    [Table("student")]
    public class Student : Person
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("student_id")]
        public int StudentId { get; set; }
        public override string ToString()
        {
            return $"StudentId:{StudentId}, FullName:{FullName}, BirthDate:{BirthDate}, Gender:{Gender}";
        }
    }
}
