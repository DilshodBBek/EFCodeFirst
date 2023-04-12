using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCodeFirst.Domain.Models
{
    [Table("subject")]

    public class Subject
    {
        [Column("subject_id")]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SubjectId { get; set; }
        [Column("subject_name")]
        public required string SubjectName { get; set; }
        public override string ToString()
        {
            return $"SubjectId:{SubjectId}, SubjectName:{SubjectName}";
        }
    }
}