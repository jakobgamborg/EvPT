using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EvPT_Tactics.Data;
using EvPT_Tactics.Models;
using EvPT_Tactics.Enum;
using Fluent.Infrastructure.FluentModel;

namespace EvPT_Tactics.Controllers
{
    public class TacticsController : Controller
    {
        private readonly EvPTContext _context;

        public TacticsController(EvPTContext context)
        {
            _context = context;
        }

        // GET: Tactics
        public async Task<IActionResult> Index()
        {
            return View(await _context.Movie.ToListAsync());
        }

        // GET: Tactics/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tactic = await _context.Movie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tactic == null)
            {
                return NotFound();
            }

            return View(tactic);
        }

        // GET: Tactics/Create
        public IActionResult Create()
        { 


            return View();
        }

        // POST: Tactics/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,CreatedDate,Map,IsTerrorist,IsAggresive,Description,ImageUrl")] Tactic tactic)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tactic);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tactic);
        }

        // GET: Tactics/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tactic = await _context.Movie.FindAsync(id);
            if (tactic == null)
            {
                return NotFound();
            }
            return View(tactic);
        }

        // POST: Tactics/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,CreatedDate,Map,IsTerrorist,IsAggresive,Description,ImageUrl")] Tactic tactic)
        {
            if (id != tactic.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tactic);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TacticExists(tactic.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tactic);
        }

        // GET: Tactics/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tactic = await _context.Movie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tactic == null)
            {
                return NotFound();
            }

            return View(tactic);
        }

        // POST: Tactics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tactic = await _context.Movie.FindAsync(id);
            _context.Movie.Remove(tactic);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TacticExists(int id)
        {
            return _context.Movie.Any(e => e.Id == id);
        }
    }
}
