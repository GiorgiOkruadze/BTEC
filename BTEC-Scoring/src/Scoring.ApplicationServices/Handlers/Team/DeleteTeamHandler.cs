using AutoMapper;
using MediatR;
using Scoring.ApplicationServices.Commands;
using Scoring.CoreServices.Repositories.Abstractions;
using Scoring.DatabaseModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Scoring.ApplicationServices.Handlers
{
    public class DeleteTeamHandler:IRequestHandler<DeleteTeamCommand,bool>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Team> _teamRepository = default;

        public DeleteTeamHandler(IRepository<Team> teamRepository, IMapper mapper)
        {
            _mapper = mapper;
            _teamRepository = teamRepository;
        }

        public async Task<bool> Handle(DeleteTeamCommand request, CancellationToken cancellationToken)
        {
            return await _teamRepository.DeleteAsync(request.Id);
        }
    }
}
