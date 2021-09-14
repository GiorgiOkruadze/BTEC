using AutoMapper;
using MediatR;
using Scoring.ApplicationServices.Queries;
using Scoring.ApplicationShared.DTOs;
using Scoring.CoreServices.Repositories.Abstractions;
using Scoring.DatabaseModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Scoring.ApplicationServices.Handlers
{
    public class ReadTeamByIdHandler : IRequestHandler<ReadTeamByIdQuery, TeamDto>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Team> _teamRepository = default;

        public ReadTeamByIdHandler(IRepository<Team> teamRepository, IMapper mapper)
        {
            _mapper = mapper;
            _teamRepository = teamRepository;
        }

        public async Task<TeamDto> Handle(ReadTeamByIdQuery request, CancellationToken cancellationToken)
        {
            var team = await _teamRepository.GetOneAsync
                (o => o.Id == request.TeamId,new List<Expression<Func<Team, object>>>() { o => o.CompletedEvents, o => o.Students });

            return _mapper.Map<TeamDto>(team);
        }
    }
}
