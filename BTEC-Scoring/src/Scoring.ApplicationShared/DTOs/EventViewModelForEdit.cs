using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Scoring.DatabaseModels.Models.Event;

namespace Scoring.ApplicationShared.DTOs
{
    public class EventViewModelForEdit
    {
        public int Id { get; set; }
        public string EventName { get; set; }
        public EventType Type { get; set; }
        public string Description { get; set; }
        public int Rank { get; set; }
        public int? PerformerTeamId { get; set; }
        public bool IsCompleted { get; set; }
        public List<TeamDto> Teams { get; set; }
    }
}
