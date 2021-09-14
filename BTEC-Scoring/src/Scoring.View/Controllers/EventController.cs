using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Scoring.ApplicationServices.Commands;
using Scoring.ApplicationServices.Queries;
using Scoring.ApplicationShared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scoring.View.Controllers
{
    public class EventController : Controller
    {
        private readonly IMediator _mediator = default;

        public EventController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: EventController
        public async Task<ActionResult> Index()
        {
            var allEvents = await _mediator.Send(new ReadAllEventsQuery());
            return View(allEvents);
        }

        // GET: EventController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EventController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([FromForm] CreateEventCommand item)
        {
            var result = await _mediator.Send(item);
            if (result)
            {
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        // GET: EventController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var currentEvent = await _mediator.Send(new GetEventByIdQuery() { EventId = id });
            var allTeams = (await _mediator.Send(new ReadAllTeamsQuery())).ToList(); ;
            var viewEvent = new EventViewModelForEdit()
            {
                EventName = currentEvent.EventName,
                Id = currentEvent.Id,
                Type = currentEvent.Type,
                Description = currentEvent.Description,
                Rank = currentEvent.Rank,
                PerformerTeamId = currentEvent.PerformerId,
                Teams = allTeams
            };

            return View(viewEvent);
        }

        // POST: EventController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, [FromForm] UpdateEventCommand item)
        {
            item.Id = id;
            var result = await _mediator.Send(item);
            if (result)
            {
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        // GET: EventController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteEventCommand() { EventId = id });
            return RedirectToAction(nameof(Index));
        }
    }
}
