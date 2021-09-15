using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scoring.ApplicationShared.DTOs
{
    public class TeamDto
    {
        public int Id { get; set; }
        public string TeamName { get; set; }
        public int MembersCount { get; set; }
        public int CompletedEventsCount { get; set; }
        public List<StudentDto> Students { get; set; }
        public List<EventPerformerDto> CompletedEvents { get; set; }

        public int Score { get; set; }
    }
}
