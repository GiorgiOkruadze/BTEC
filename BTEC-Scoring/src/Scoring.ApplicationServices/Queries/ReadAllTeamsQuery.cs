using MediatR;
using Scoring.ApplicationShared.DTOs;
using System.Collections.Generic;

namespace Scoring.ApplicationServices.Queries
{
    public class ReadAllTeamsQuery : IRequest<IEnumerable<TeamDto>> { }
}
