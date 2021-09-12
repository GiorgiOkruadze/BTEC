using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Scoring.ApplicationServices.Queries;
using Scoring.CoreServices.Repositories.Abstractions;
using Scoring.DatabaseModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TeamController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TeamController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TeamController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TeamController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TeamController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TeamController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
