using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scoring.ApplicationShared.DTOs
{
    public class TeamDto
    {
        public string TeamName { get; set; }
        public int MembersCount { get; set; }
        public int CompletedEventsCount { get; set; }
    }
}
