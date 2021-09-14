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
    public class UpdateEventCommandHandler:IRequestHandler<UpdateEventCommand,bool>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Event> _eventRepository = default;
        private readonly IRepository<Team> _teamRepository = default;
        private readonly IRepository<EventPerformer> _eventPerformerRepository = default;

        public UpdateEventCommandHandler(IRepository<Event> eventRepository, 
            IRepository<Team> teamRepository,
            IRepository<EventPerformer> eventPerformerRepository,
            IMapper mapper)
        {
            _mapper = mapper;
            _eventRepository = eventRepository;
            _teamRepository = teamRepository;
            _eventPerformerRepository = eventPerformerRepository;
        }

        public async Task<bool> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
        {
            if (request.IsCompleted)
            {
                var eventPerformer = new EventPerformer()
                {
                    TeamId = request.PerformerTeamId,
                    PerformDate = DateTime.Now,
                };
                var performerId = await _eventPerformerRepository.CreateAndGetIdAsync(eventPerformer);
                request.PerformerId = performerId;
            }
            var currentEvent = _mapper.Map<Event>(request);
            var result = await _eventRepository.UpdateAsync(request.Id,currentEvent);
            return result;
        }
    }
}
