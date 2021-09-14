using AutoMapper;
using MediatR;
using Scoring.ApplicationServices.Commands;
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
    public class DeleteEventCommandHandler:IRequestHandler<DeleteEventCommand,bool>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Event> _eventRepository = default;

        public DeleteEventCommandHandler(IRepository<Event> eventRepository, IMapper mapper)
        {
            _mapper = mapper;
            _eventRepository = eventRepository;
        }

        public async Task<bool> Handle(DeleteEventCommand request, CancellationToken cancellationToken)
        {
            var result = false;
            var eventStatus = (await _eventRepository.GetOneAsync(o => o.Id == request.EventId, new List<Expression<Func<Event, object>>>())).IsCompleted;
            if (!eventStatus)
            {
                result = await _eventRepository.DeleteAsync(request.EventId);
            }
            return result;
        }
    }
}
