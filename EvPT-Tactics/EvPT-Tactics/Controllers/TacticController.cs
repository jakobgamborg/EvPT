using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EvPT_Tactics.Models;
using EvPT_Tactics.Data;

namespace EvPT_Tactics.Controllers
{
    public class TacticController : Controller
    {
        private readonly ILogger<TacticController> _logger;
        private readonly EvPTContext _context;

        public TacticController(ILogger<TacticController> logger, EvPTContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create(Tactic model)
        {
            if (ModelState.IsValid)
            {
                Tactic created = model;
                _context.Add(created);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            {
                return View();
            }

        }
    }
}
