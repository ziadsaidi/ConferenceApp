using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ConferenceApp.Models;
using ConferenceApp.Services;
using Shared.Models;

namespace ConferenceApp.Controllers
{
    public class ConferenceController : Controller
    {
        private readonly IConferenceService conferenceService;
        private readonly ILogger<ConferenceController> _logger;

        public ConferenceController(
            IConferenceService conferenceService,
            ILogger<ConferenceController> logger)
        {
            this.conferenceService = conferenceService;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Title = "Conferences";
            return View(await conferenceService.GetAll());
        }

        public IActionResult Add(){
            ViewBag.Title = "Add Conference";
            return View(new ConferenceModel());
        }
       [HttpPost]
        public async Task<IActionResult> Add(ConferenceModel model){
          if(ModelState.IsValid)
                await conferenceService.Add(model);

            return RedirectToAction("Index");

        }

    
    }
}
