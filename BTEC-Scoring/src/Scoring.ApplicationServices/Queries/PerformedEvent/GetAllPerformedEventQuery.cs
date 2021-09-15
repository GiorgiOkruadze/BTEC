using MediatR;
using Scoring.ApplicationShared.DTOs;
using Scoring.DatabaseModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scoring.ApplicationServices.Queries
{
    public class GetAllPerformedEventQuery : IRequest<IEnumerable<EventPerformerDto>> { }
}
