using AutoMapper;
using MediatR;
using Scoring.ApplicationServices.Commands;
using Scoring.CoreServices.Repositories.Abstractions;
using Scoring.DatabaseModels.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Scoring.ApplicationServices.Handlers
{
    public class CreateTeamHandler : IRequestHandler<CreateTeamCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Team> _teamRepository = default;

        public CreateTeamHandler(IRepository<Team> teamRepository, IMapper mapper)
        {
            _mapper = mapper;
            _teamRepository = teamRepository;
        }

        public async Task<bool> Handle(CreateTeamCommand request, CancellationToken cancellationToken)
        {
            var students = _mapper.Map<List<Student>>(request.Students);
            var team = new Team() { Students = students, TeamName = request.TeamName };
            return await _teamRepository.CreateAsync(team);
        }
    }
}
