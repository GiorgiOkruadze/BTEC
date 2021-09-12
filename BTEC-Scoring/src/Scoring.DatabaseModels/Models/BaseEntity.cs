using System.ComponentModel.DataAnnotations;

namespace Scoring.DatabaseModels.Models
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
