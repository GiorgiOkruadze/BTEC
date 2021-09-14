using MediatR;
using Scoring.ApplicationShared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scoring.ApplicationServices.Queries
{
    public class ReadAllEventsQuery : IRequest<IEnumerable<EventDto>> { }
}
