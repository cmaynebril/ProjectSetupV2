using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectSetupV2.Models.Context;

namespace ProjectSetupV2.Controllers
{
    public class AssigneesController : Controller
    {
        private readonly DBProjectSetupContext _context;

        public AssigneesController(DBProjectSetupContext context)
        {
            _context = context;
        }

        // GET: Assignees
        public async Task<IActionResult> Index()
        {
            return View(await _context.Assignees.ToListAsync());
        }

        // GET: Assignees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assignees = await _context.Assignees
                .FirstOrDefaultAsync(m => m.Id == id);
            if (assignees == null)
            {
                return NotFound();
            }

            return View(assignees);
        }

        // GET: Assignees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Assignees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Assignee,AssigneeRate")] Assignees assignees)
        {
            if (ModelState.IsValid)
            {
                _context.Add(assignees);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(assignees);
        }

        // GET: Assignees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assignees = await _context.Assignees.FindAsync(id);
            if (assignees == null)
            {
                return NotFound();
            }
            return View(assignees);
        }

        // POST: Assignees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Assignee,AssigneeRate")] Assignees assignees)
        {
            if (id != assignees.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(assignees);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssigneesExists(assignees.Id))
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
            return View(assignees);
        }

        // GET: Assignees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assignees = await _context.Assignees
                .FirstOrDefaultAsync(m => m.Id == id);
            if (assignees == null)
            {
                return NotFound();
            }

            return View(assignees);
        }

        // POST: Assignees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var assignees = await _context.Assignees.FindAsync(id);
            _context.Assignees.Remove(assignees);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssigneesExists(int id)
        {
            return _context.Assignees.Any(e => e.Id == id);
        }
    }
}
