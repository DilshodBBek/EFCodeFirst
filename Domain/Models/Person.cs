using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCodeFirst.Domain.Models
{
    public abstract class Person 
    {
        [Column("full_name")]
        public required string FullName { get; set; }
        [Column("birth_date")]
        public DateTime BirthDate { get; set; }
        /// <summary>
        /// True = Male
        /// False = Female 
        /// </summary>
        [Column("gender")]
        public bool Gender { get; set; } = true;
        

    }
}
