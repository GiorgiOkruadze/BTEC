using MediatR;
using Scoring.ApplicationShared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scoring.ApplicationServices.Commands
{
    public class UpdatePerformerdEventCommand:IRequest<bool>
    {
        public int Id { get; set; }
        public int? TeamId { get; set; }
        public DateTime PerformDate { get; set; }
        public bool SuccessfullyCompleted { get; set; }
        public TeamDto PerformerTeam { get; set; }
        public string EventStorySource { get; set; }
    }
}
