﻿using Adhira.WebUI.AppCode.Modules.ContactPostModule;
using Adhira.WebUI.Models.DataContexts;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adhira.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactPostsController : Controller
    {
        private readonly IMediator mediator;
        private readonly AdhiraDbContext db;

        public ContactPostsController(IMediator mediator, AdhiraDbContext db)
        {
            this.mediator = mediator;
            this.db = db;
        }
        public async Task<IActionResult> Index(ContactAllQuery query)
        {
            var data = await mediator.Send(query);
            return View(data);
        }
        public async Task<IActionResult> Details(ContactSingleQuery query)
        {
            var data = await mediator.Send(query);
            return View(data);
        }
        public async Task<IActionResult> Answer(ContactSingleQuery query)
        {
            var data = await mediator.Send(query);

            if (data.AnsweredDate != null)
            {
                return RedirectToAction(nameof(Details), routeValues: new
                {
                    id = query.Id
                });
            }

            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> Answer(ContactAnswerCommand command)
        {
            var data = await mediator.Send(command);

            if (!ModelState.IsValid)
            {
                return View(data);
            }
            return RedirectToAction(nameof(Details), routeValues: new
            {
                id = command.Id
            });
        }
    }
}
