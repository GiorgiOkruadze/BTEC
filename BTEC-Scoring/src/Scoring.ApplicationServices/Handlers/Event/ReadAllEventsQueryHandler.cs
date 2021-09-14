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
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Scoring.ApplicationServices.Handlers
{
    public class ReadAllEventsQueryHandler:IRequestHandler<ReadAllEventsQuery,IEnumerable<EventDto>>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Event> _eventRepository = default;

        public ReadAllEventsQueryHandler(IRepository<Event> eventRepository, IMapper mapper)
        {
            _mapper = mapper;
            _eventRepository = eventRepository;
        }

        public async Task<IEnumerable<EventDto>> Handle(ReadAllEventsQuery request, CancellationToken cancellationToken)
        {
            var events = await _eventRepository.GetAllAsync(new List<Expression<Func<Event, object>>>() { });
            return _mapper.Map<List<EventDto>>(events);
        }
    }
}
