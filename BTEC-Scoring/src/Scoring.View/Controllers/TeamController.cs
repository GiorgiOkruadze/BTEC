using MediatR;
using Microsoft.AspNetCore.Mvc;
using Scoring.ApplicationServices.Commands;
using Scoring.ApplicationServices.Extensions;
using Scoring.ApplicationServices.Queries;
using Scoring.ApplicationShared.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Scoring.View.Controllers
{
    public class TeamController : Controller
    {
        private readonly IMediator _mediator = default;

        public TeamController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: TeamController
        public async Task<ActionResult> Index()
        {
            var allTeams = await _mediator.Send(new ReadAllTeamsQuery());
            return View(allTeams);
        }

        // GET: TeamController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var team = await _mediator.Send(new ReadTeamByIdQuery() { TeamId = id});
            return View(team);
        }


        // GET: TeamController/Create
        public ActionResult Create()
        {
            var teamCommand = new CreateTeamCommand()
            {
                Students = new List<StudentDto>().AddItemsInCollection(5)
            };
            return View(teamCommand);
        }

        // POST: TeamController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([FromForm] CreateTeamCommand team)
        {
            var result = await _mediator.Send(team);
            if (result) { 
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        // GET: TeamController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var team = await _mediator.Send(new ReadTeamByIdQuery() { TeamId = id });
            team.Students.AddItemsInCollection(5 - team.Students.Count);
            return View(team);
        }

        // POST: TeamController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, [FromForm] UpdateTeamCommand team)
        {
            team.Id = id;
            var result = await _mediator.Send(team);
            if (result)
            {
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        // GET: TeamController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteTeamCommand() { Id = id } );
            if (result)
            {
                return RedirectToAction(nameof(Index));
            }

            return View();
        }
    }
}
