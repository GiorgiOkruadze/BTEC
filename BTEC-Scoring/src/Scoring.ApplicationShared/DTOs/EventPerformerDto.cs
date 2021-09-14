using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scoring.ApplicationShared.DTOs
{
    public class EventPerformerDto
    {
        public int Id { get; set; }
        public int? TeamId { get; set; }
        public DateTime PerformDate { get; set; }
        public bool SuccessfullyCompleted { get; set; }
        public string EventStorySource { get; set; }
    }
}
