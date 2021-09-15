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
    public class UpdatePerformerdEventCommandHandler : IRequestHandler<UpdatePerformerdEventCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<EventPerformer> _performerRepository = null;
        public UpdatePerformerdEventCommandHandler(IRepository<EventPerformer> performerRepository, IMapper mapper)
        {
            _mapper = mapper;
            _performerRepository = performerRepository;
        }

        public async Task<bool> Handle(UpdatePerformerdEventCommand request, CancellationToken cancellationToken)
        {
            var performerdEvent = _mapper.Map<EventPerformer>(request);
            var result = await _performerRepository.UpdateAsync(request.Id,performerdEvent);
            return result;
        }
    }
}
