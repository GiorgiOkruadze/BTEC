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
using System.Threading;
using System.Threading.Tasks;

namespace Scoring.ApplicationServices.Handlers
{
    public class ReadAllTeamsHandler : IRequestHandler<ReadAllTeamsQuery, IEnumerable<TeamDto>>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Team> _teamRepository = default;
        private readonly IRepository<EventPerformer> _eventPerformerRepository = default;

        public ReadAllTeamsHandler(IRepository<Team> teamRepository, IRepository<EventPerformer> eventPerformerRepository, IMapper mapper)
        {
            _mapper = mapper;
            _teamRepository = teamRepository;
            _eventPerformerRepository = eventPerformerRepository;
        }

        public async Task<IEnumerable<TeamDto>> Handle(ReadAllTeamsQuery request, CancellationToken cancellationToken)
        {
            var teams = await _teamRepository.GetAllAsync(new List<Expression<Func<Team, object>>>() { o => o.Students, o => o.CompletedEvents });
            foreach(var tm in teams)
            {
                tm.CompletedEvents = (await _eventPerformerRepository.GetAsync(o => o.TeamId == tm.Id, new List<Expression<Func<EventPerformer, object>>>() { ep => ep.Event })).ToList();
            }
            var mappedTeams = _mapper.Map<List<TeamDto>>(teams).OrderBy(o => o.Score);
            return mappedTeams;
        }
    }
}
