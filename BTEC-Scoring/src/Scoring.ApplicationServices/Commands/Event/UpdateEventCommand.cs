using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Scoring.DatabaseModels.Models.Event;

namespace Scoring.ApplicationServices.Commands
{
    public class UpdateEventCommand:IRequest<bool>
    {
        public int Id { get; set; }
        public string EventName { get; set; }
        public EventType Type { get; set; }
        public string Description { get; set; }
        public int Rank { get; set; }
        public bool IsCompleted { get; set; }
        public int? PerformerTeamId { get; set; }
        public int? PerformerId { get; set; }
    }
}
