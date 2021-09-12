using System.ComponentModel.DataAnnotations.Schema;

namespace Scoring.DatabaseModels.Models
{
    public class Student:BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public int TeamId { get; set; }
        [ForeignKey("TeamId")]
        public Team Team { get; set; }
    }
}
