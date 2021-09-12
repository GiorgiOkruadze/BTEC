using System.ComponentModel.DataAnnotations.Schema;

namespace Scoring.DatabaseModels.Models
{
    public class Event:BaseEntity
    {
        public string EventName { get; set; }
        public enum EventType {  Sporting, AcademicChallenge }
        public EventType Type { get; set; }
        public string Description { get; set; }
        public int Rank { get; set; }
        public int? PerformerId { get; set; }
        [ForeignKey("PerformerId")]
        public EventPerformer Performer { get; set; }
        public bool IsCompleted { get; set; }
    }
}
