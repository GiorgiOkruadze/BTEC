using AutoMapper;
using MediatR;
using Scoring.ApplicationServices.Commands;
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
    public class UpdateTeamHandler:IRequestHandler<UpdateTeamCommand,bool>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Team> _teamRepository = default;
        private readonly IRepository<Student> _studentRepository = default;

        public UpdateTeamHandler(IRepository<Team> teamRepository, IRepository<Student> studentRepository, IMapper mapper)
        {
            _mapper = mapper;
            _teamRepository = teamRepository;
            _studentRepository = studentRepository;
        }

        public async Task<bool> Handle(UpdateTeamCommand request, CancellationToken cancellationToken)
        {
            var team = _mapper.Map<Team>(request);
            var currentTeam = await _teamRepository.GetOneAsync(o => o.Id == request.Id, new List<Expression<Func<Team, object>>>() { o => o.Students });
            var deletedStudents = currentTeam.Students.Where(s => !request.Students.Select(rs => rs.Id).Contains(s.Id)).ToList();
            foreach(var dlStudent in deletedStudents)
            {
                await _studentRepository.DeleteAsync(dlStudent.Id);
            }

            var result = await _teamRepository.UpdateAsync(request.Id, team);
            return result;
        }
    }
}
