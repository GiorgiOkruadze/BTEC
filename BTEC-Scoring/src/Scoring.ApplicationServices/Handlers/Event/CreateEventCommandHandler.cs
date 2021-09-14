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
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Event> _eventRepository = default;

        public CreateEventCommandHandler(IRepository<Event> eventRepository, IMapper mapper)
        {
            _mapper = mapper;
            _eventRepository = eventRepository;
        }

        public async Task<bool> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            var currentEvent = _mapper.Map<Event>(request);
            var result = await _eventRepository.CreateAsync(currentEvent);
            return result;
        }
    }
}
