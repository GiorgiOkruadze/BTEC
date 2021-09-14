using static Scoring.DatabaseModels.Models.Event;

namespace Scoring.ApplicationShared.DTOs
{
    public class EventDto
    {
        public int Id { get; set; }
        public string EventName { get; set; }
        public EventType Type { get; set; }
        public string Description { get; set; }
        public int Rank { get; set; }
        public int? PerformerId { get; set; }
        public int? PerformerTeamId { get; set; }
        public bool IsCompleted { get; set; }
    }
}
