using System.Collections.Generic;

namespace Scoring.DatabaseModels.Models
{
    public class Team:BaseEntity
    {
        public string TeamName { get; set; }
        public int MembersCount { get; set; }
        public List<Student> Students { get; set; }
        public List<EventPerformer> CompletedEvents { get; set; }
    }
}
