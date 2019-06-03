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
    public class JobsController : Controller
    {
        private readonly DBProjectSetupContext _context;

        public JobsController(DBProjectSetupContext context)
        {
            _context = context;
        }

        // GET: Jobs
        public async Task<IActionResult> Index()
        {
            var dBProjectSetupContext = _context.Jobs.Include(j => j.Client);
            return View(await dBProjectSetupContext.ToListAsync());
        }

        // GET: Jobs/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobs = await _context.Jobs
                .Include(j => j.Client)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jobs == null)
            {
                return NotFound();
            }

            return View(jobs);
        }

        // GET: Jobs/Create
        public IActionResult Create()
        {
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Client");
            var status = _context.JobStatus.ToList();
            var statusList = new List<SelectListItem>();
            foreach (var item in status)
            {
                statusList.Add(new SelectListItem { Value = item.Status.ToString(), Text = item.Status.ToString() });
            }
            ViewBag.statusList = statusList;
            return View();
        }

        // POST: Jobs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Jobs jobs)
        {
            var clientname = _context.Clients.Where(x => x.Id == jobs.ClientId).FirstOrDefault();
            if (ModelState.IsValid)
            {
                jobs.ClientName = clientname.Client;

                _context.Add(jobs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Client", jobs.ClientId);
            return View(jobs);
        }

        // GET: Jobs/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobs = await _context.Jobs.FindAsync(id);
            if (jobs == null)
            {
                return NotFound();
            }
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Client", jobs.ClientId);
            var status = _context.JobStatus.ToList();
            var statusList = new List<SelectListItem>();
            foreach (var item in status)
            {
                statusList.Add(new SelectListItem { Value = item.Status.ToString(), Text = item.Status.ToString() });
            }
            ViewBag.statusList = statusList;
            return View(jobs);
        }

        // POST: Jobs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, Jobs jobs)
        {
            if (id != jobs.Id)
            {
                return NotFound();
            }
            var clientname = _context.Clients.Where(x => x.Id == jobs.ClientId).FirstOrDefault();
            if (ModelState.IsValid)
            {
                try
                {
                    jobs.ClientName = clientname.Client;
                    _context.Update(jobs);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobsExists(jobs.Id))
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
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Client", jobs.ClientId);
            return View(jobs);
        }

        // GET: Jobs/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobs = await _context.Jobs
                .Include(j => j.Client)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jobs == null)
            {
                return NotFound();
            }

            return View(jobs);
        }

        // POST: Jobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var taskslist = _context.Tasks.Where(x => x.JobId == id).ToList();
            foreach (var item in taskslist)
            {
                _context.Tasks.Remove(item);
            }


            var projects = await _context.Jobs.FindAsync(id);
            _context.Jobs.Remove(projects);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JobsExists(long id)
        {
            return _context.Jobs.Any(e => e.Id == id);
        }
    }
}
