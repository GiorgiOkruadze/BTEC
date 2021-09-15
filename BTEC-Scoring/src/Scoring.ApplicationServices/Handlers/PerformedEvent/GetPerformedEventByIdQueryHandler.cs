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
    public class GetPerformedEventByIdQueryHandler : IRequestHandler<GetPerformedEventByIdQuery, EventPerformerDto>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<EventPerformer> _performerRepository = null;
        public GetPerformedEventByIdQueryHandler(IRepository<EventPerformer> performerRepository, IMapper mapper)
        {
            _mapper = mapper;
            _performerRepository = performerRepository;
        }

        public async Task<EventPerformerDto> Handle(GetPerformedEventByIdQuery request, CancellationToken cancellationToken)
        {
            var allPerformerEvents = await _performerRepository.GetOneAsync(o => o.Id == request.PerformerEventId,new List<Expression<Func<EventPerformer, object>>>() { o => o.PerformerTeam });

            return _mapper.Map<EventPerformerDto>(allPerformerEvents);
        }
    }
}
