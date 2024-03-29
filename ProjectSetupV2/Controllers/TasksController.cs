﻿using System;
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
    public class TasksController : Controller
    {
        private readonly DBProjectSetupContext _context;

        public TasksController(DBProjectSetupContext context)
        {
            _context = context;
        }

        // GET: Tasks
        public async Task<IActionResult> Index()
        {
            var dBProjectSetupContext = _context.Tasks.Include(t => t.BusinessValues).Include(t => t.Job).Include(t => t.InvoiceType);
            return View(await dBProjectSetupContext.ToListAsync());
        }

        // GET: Tasks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tasks = await _context.Tasks
                .Include(t => t.BusinessValues)
                .Include(t => t.Job)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tasks == null)
            {
                return NotFound();
            }

            return View(tasks);
        }

        // GET: Tasks/Create
        public IActionResult Create()
        {
            ViewData["BusinessValuesId"] = new SelectList(_context.BusinessValues, "Id", "Business");
            ViewData["JobId"] = new SelectList(_context.Jobs, "Id", "Job");
            ViewData["InvoiceTypeId"] = new SelectList(_context.InvoiceType, "Id", "Type");

            var status = _context.TasksStatus.ToList();
            var statusList = new List<SelectListItem>();
            foreach (var item in status)
            {
                statusList.Add(new SelectListItem { Value = item.Status.ToString(), Text = item.Status.ToString() });
            }
            ViewBag.taskstatusList = statusList;

            return View();
        }

        // POST: Tasks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Task,JobId,BusinessValuesId,TasksRate,TaskStatus,InvoiceTypeId")] Tasks tasks)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tasks);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BusinessValuesId"] = new SelectList(_context.BusinessValues, "Id", "Business", tasks.BusinessValuesId);
            ViewData["JobId"] = new SelectList(_context.Jobs, "Id", "Id", tasks.JobId);
            ViewData["InvoiceTypeId"] = new SelectList(_context.InvoiceType, "Id", "Type");
            return View(tasks);
        }

        // GET: Tasks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tasks = await _context.Tasks.FindAsync(id);
            if (tasks == null)
            {
                return NotFound();
            }
            ViewData["BusinessValuesId"] = new SelectList(_context.BusinessValues, "Id", "Business", tasks.BusinessValuesId);
            ViewData["JobId"] = new SelectList(_context.Jobs, "Id", "Job", tasks.Job);
            ViewData["InvoiceTypeId"] = new SelectList(_context.InvoiceType, "Id", "Type");
            var status = _context.TasksStatus.ToList();
            var statusList = new List<SelectListItem>();
            foreach (var item in status)
            {
                statusList.Add(new SelectListItem { Value = item.Status.ToString(), Text = item.Status.ToString() });
            }
            ViewBag.taskstatusList = statusList;

            return View(tasks);
        }

        // POST: Tasks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Task,JobId,BusinessValuesId,TasksRate,Status,InvoiceTypeId")] Tasks tasks)
        {
            if (id != tasks.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tasks);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TasksExists(tasks.Id))
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
            ViewData["BusinessValuesId"] = new SelectList(_context.BusinessValues, "Id", "Business", tasks.BusinessValuesId);
            ViewData["JobId"] = new SelectList(_context.Jobs, "Id", "Id", tasks.JobId);
            ViewData["InvoiceTypeId"] = new SelectList(_context.InvoiceType, "Id", "Type");
            return View(tasks);
        }

        // GET: Tasks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tasks = await _context.Tasks
                .Include(t => t.BusinessValues)
                .Include(t => t.Job)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tasks == null)
            {
                return NotFound();
            }

            return View(tasks);
        }

        // POST: Tasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tasks = await _context.Tasks.FindAsync(id);
            _context.Tasks.Remove(tasks);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TasksExists(int id)
        {
            return _context.Tasks.Any(e => e.Id == id);
        }
    }
}
