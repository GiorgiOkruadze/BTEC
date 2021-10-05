using AutoMapper;
using MediatR;
using Scoring.ApplicationServices.Commands;
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
            var teams = (await _teamRepository.GetAllAsync(new List<Expression<Func<Team, object>>>() { team => team.Students })).ToList();
            var bigTeamsCount = teams.Where(team => team.Students.Count > 1).Count();
            var smallTeamsCount = teams.Where(team => team.Students.Count == 1).Count();
            var students = _mapper.Map<List<Student>>(request.Students);

            if(students.Count == 1 && smallTeamsCount>=20 || students.Count > 1 && bigTeamsCount >= 4)
            {
                return false;
            }

            var team = new Team() { Students = students, TeamName = request.TeamName };
            return await _teamRepository.CreateAsync(team);
        }
    }
}
