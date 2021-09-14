using AutoMapper;
using MediatR;
using Scoring.ApplicationServices.Queries;
using Scoring.ApplicationShared.DTOs;
using Scoring.CoreServices.Repositories.Abstractions;
using Scoring.DatabaseModels.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Scoring.ApplicationServices.Handlers
{
    public class ReadAllTeamsHandler : IRequestHandler<ReadAllTeamsQuery, IEnumerable<TeamDto>>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Team> _teamRepository = default;

        public ReadAllTeamsHandler(IRepository<Team> teamRepository, IMapper mapper)
        {
            _mapper = mapper;
            _teamRepository = teamRepository;
        }

        public async Task<IEnumerable<TeamDto>> Handle(ReadAllTeamsQuery request, CancellationToken cancellationToken)
        {
            var teams = await _teamRepository.GetAllAsync(new List<Expression<Func<Team, object>>>() { o => o.Students, o => o.CompletedEvents });
            return _mapper.Map<List<TeamDto>>(teams);
        }
    }
}
