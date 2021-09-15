using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Scoring.ApplicationServices.Commands;
using Scoring.ApplicationServices.FileStorageServices;
using Scoring.ApplicationServices.Queries;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Scoring.View.Controllers
{
    public class PerformedEventController : Controller
    {
        private readonly IMediator _mediator = default;

        public PerformedEventController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: PerformedEventController
        public async Task<ActionResult> Index()
        {
            var allPerformerEvents = await _mediator.Send(new GetAllPerformedEventQuery());
            return View(allPerformerEvents);
        }

        // GET: PerformedEventController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var performerEvents = await _mediator.Send(new GetPerformedEventByIdQuery() { PerformerEventId = id });
            return View(performerEvents);
        }
        
        // GET: PerformedEventController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var performerEvents = await _mediator.Send(new GetPerformedEventByIdQuery() { PerformerEventId = id });
            return View(performerEvents);
        }

        // POST: PerformedEventController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, UpdatePerformerdEventCommand performedEvent)
        {
            var file = Request.Form.Files[0];
            string fileExtensions = Path.GetFileName(file.FileName).Split(".").Last();
            var folderFullPath = @"C:\Users\User\Desktop\BTEC\BTEC-Scoring\src\Scoring.View\wwwroot\uploadedVideos";
            string path = Path.Combine(folderFullPath, $"{Guid.NewGuid()}.{fileExtensions}");
            using (Stream fileStream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            CloudinaryService service = new CloudinaryService();
            var url = service.UploadFile(path);

            DirectoryInfo di = new DirectoryInfo(folderFullPath);
            foreach (FileInfo fl in di.GetFiles())
            {
                fl.Delete();
            }
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                dir.Delete(true);
            }

            performedEvent.Id = id;
            performedEvent.EventStorySource = url;

            var result = await _mediator.Send(performedEvent);
            if (result)
            {
                return RedirectToAction(nameof(Index));
            }

            return View();
        }
    }
}
