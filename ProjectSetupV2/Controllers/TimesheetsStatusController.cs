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
    public class TimesheetsStatusController : Controller
    {
        private readonly DBProjectSetupContext _context;

        public TimesheetsStatusController(DBProjectSetupContext context)
        {
            _context = context;
        }

        // GET: TimesheetsStatus
        public async Task<IActionResult> Index()
        {
            return View(await _context.TimesheetsStatus.ToListAsync());
        }

        // GET: TimesheetsStatus/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timesheetsStatus = await _context.TimesheetsStatus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (timesheetsStatus == null)
            {
                return NotFound();
            }

            return View(timesheetsStatus);
        }

        // GET: TimesheetsStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TimesheetsStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Status")] TimesheetsStatus timesheetsStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(timesheetsStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(timesheetsStatus);
        }

        // GET: TimesheetsStatus/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timesheetsStatus = await _context.TimesheetsStatus.FindAsync(id);
            if (timesheetsStatus == null)
            {
                return NotFound();
            }
            return View(timesheetsStatus);
        }

        // POST: TimesheetsStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Status")] TimesheetsStatus timesheetsStatus)
        {
            if (id != timesheetsStatus.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(timesheetsStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TimesheetsStatusExists(timesheetsStatus.Id))
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
            return View(timesheetsStatus);
        }

        // GET: TimesheetsStatus/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timesheetsStatus = await _context.TimesheetsStatus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (timesheetsStatus == null)
            {
                return NotFound();
            }

            return View(timesheetsStatus);
        }

        // POST: TimesheetsStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var timesheetsStatus = await _context.TimesheetsStatus.FindAsync(id);
            _context.TimesheetsStatus.Remove(timesheetsStatus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TimesheetsStatusExists(long id)
        {
            return _context.TimesheetsStatus.Any(e => e.Id == id);
        }
    }
}
