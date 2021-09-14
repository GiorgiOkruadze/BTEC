using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scoring.ApplicationServices.Commands
{
    public class DeleteEventCommand:IRequest<bool>
    {
        public int EventId { get; set; }
    }
}
