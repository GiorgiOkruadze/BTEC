using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Scoring.DatabaseModels.Models.Event;

namespace Scoring.ApplicationServices.Commands
{
    public class CreateEventCommand:IRequest<bool>
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Fill Team Name Property")]
        public string EventName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Fill Team Name Property")]
        public EventType Type { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Fill Team Name Property")]
        public string Description { get; set; }
        public int Rank { get; set; }
        public bool IsCompleted { get; set; }
    }
}
