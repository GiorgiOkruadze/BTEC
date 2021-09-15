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
    public class GetAllPerformedEventQueryHandler:IRequestHandler<GetAllPerformedEventQuery,IEnumerable<EventPerformerDto>>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<EventPerformer> _performerRepository = null;
        public GetAllPerformedEventQueryHandler(IRepository<EventPerformer> performerRepository, IMapper mapper)
        {
            _mapper = mapper;
            _performerRepository = performerRepository;
        }

        public async Task<IEnumerable<EventPerformerDto>> Handle(GetAllPerformedEventQuery request, CancellationToken cancellationToken)
        {
            var allPerformerEvents = await _performerRepository.GetAllAsync(new List<Expression<Func<EventPerformer, object>>>() {o=>o.Event, o => o.PerformerTeam });

            return _mapper.Map<List<EventPerformerDto>>(allPerformerEvents);
        }
    }
}
