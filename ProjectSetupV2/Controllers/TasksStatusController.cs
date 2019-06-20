using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectSetupV2.Models.Context;

namespace ProjectSetupV2.Controllers
{
    [Authorize]
    public class TasksStatusController : Controller
    {
        private readonly DBProjectSetupContext _context;

        public TasksStatusController(DBProjectSetupContext context)
        {
            _context = context;
        }

        // GET: TasksStatus
        public async Task<IActionResult> Index()
        {
            return View(await _context.TasksStatus.ToListAsync());
        }

        // GET: TasksStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tasksStatus = await _context.TasksStatus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tasksStatus == null)
            {
                return NotFound();
            }

            return View(tasksStatus);
        }

        // GET: TasksStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TasksStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Status")] TasksStatus tasksStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tasksStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tasksStatus);
        }

        // GET: TasksStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tasksStatus = await _context.TasksStatus.FindAsync(id);
            if (tasksStatus == null)
            {
                return NotFound();
            }
            return View(tasksStatus);
        }

        // POST: TasksStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Status")] TasksStatus tasksStatus)
        {
            if (id != tasksStatus.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tasksStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TasksStatusExists(tasksStatus.Id))
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
            return View(tasksStatus);
        }

        // GET: TasksStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tasksStatus = await _context.TasksStatus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tasksStatus == null)
            {
                return NotFound();
            }

            return View(tasksStatus);
        }

        // POST: TasksStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tasksStatus = await _context.TasksStatus.FindAsync(id);
            _context.TasksStatus.Remove(tasksStatus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TasksStatusExists(int id)
        {
            return _context.TasksStatus.Any(e => e.Id == id);
        }
    }
}
