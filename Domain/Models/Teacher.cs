using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCodeFirst.Domain.Models
{
    [Table("teacher")]
    public class Teacher : Person
    {
        [Column("teacher_id")]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TeacherId { get; set; }
        public override string ToString()
        {
            return $"TeacherId:{TeacherId}, FullName:{FullName}, BirthDate:{BirthDate}, Gender:{Gender}";

        }
    }
}
