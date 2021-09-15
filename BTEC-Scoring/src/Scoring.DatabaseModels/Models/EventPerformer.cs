using System;

namespace Scoring.DatabaseModels.Models
{
    public class EventPerformer:BaseEntity
    {
        public int? TeamId { get; set; }
        public Team PerformerTeam { get; set; }
        public DateTime PerformDate { get; set; }
        public bool SuccessfullyCompleted { get; set; }
        public string EventStorySource { get; set; }
        public Event Event { get; set; }
    }
}
