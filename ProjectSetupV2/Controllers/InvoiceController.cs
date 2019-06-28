using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectSetupV2.Models;
using ProjectSetupV2.Models.Context;

namespace ProjectSetupV2.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly DBProjectSetupContext _context;

        public InvoiceController(DBProjectSetupContext context)
        {
            _context = context;
        }

        // GET: Invoice
        public async Task<IActionResult> Index()
        {
            var dBProjectSetupContext = _context.JobTasks.Include(j => j.BusinessValue).Include(j => j.Client).Include(j => j.Job).Include(j => j.Task).Include(j => j.User);
            return View(await dBProjectSetupContext.ToListAsync());
        }

        // GET: Invoice/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobTasks = await _context.JobTasks
                .Include(j => j.BusinessValue)
                .Include(j => j.Client)
                .Include(j => j.Job)
                .Include(j => j.Task)
                .Include(j => j.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jobTasks == null)
            {
                return NotFound();
            }

            return View(jobTasks);
        }

        // GET: Invoice/Create
        public IActionResult Create()
        {
            //List<Clients> clientList = new List<Clients>();
            //clientList = (from clients in _context.Clients
            //              select clients).ToList();

            //ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Client");
            //ViewData["BusinessValueId"] = new SelectList(_context.BusinessValues, "Id", "Id");
            //ViewData["JobId"] = new SelectList(_context.Jobs, "Id", "Id");
            //ViewData["TaskId"] = new SelectList(_context.Tasks, "Id", "Id");
            //ViewData["AssigneeId"] = new SelectList(_context.Users, "Id", "Id");
            List<Clients> clientList = new List<Clients>();
            clientList = (from Clients in _context.Clients
                          select Clients).ToList();
            clientList.Insert(0, new Clients { Id = 0, Client = "Select" });
            ViewBag.ListofClients = clientList;

            return View();
        }
        public JsonResult GetJobCategory(int Id)
        {
            List<Jobs> jobList = new List<Jobs>();
            jobList = (from job in _context.Jobs
                       where job.ClientId == Id 
                       select job).ToList();
            var result = from job in _context.Jobs
                         where job.ClientId == Id && job.Status == "Done"
                         select new { job.Id, job.Job };
            return Json(result);
        }
        public JsonResult GetTaskCategory(int Id)
        {
            List<Tasks> taskList = new List<Tasks>();
            taskList = (from task in _context.Tasks
                       where task.JobId == Id && task.Status == "Done"
                        select task).ToList();
            return Json(new SelectList(taskList, "Id", "Task"));
        }

        // POST: Invoice/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DateCreated,Status,Description,TimeSpent,TaskId,JobId,ClientId,BusinessValueId,AssigneeId")] JobTasks jobTasks)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jobTasks);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BusinessValueId"] = new SelectList(_context.BusinessValues, "Id", "Id", jobTasks.BusinessValueId);
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Id", jobTasks.ClientId);
            ViewData["JobId"] = new SelectList(_context.Jobs, "Id", "Id", jobTasks.JobId);
            ViewData["TaskId"] = new SelectList(_context.Tasks, "Id", "Id", jobTasks.TaskId);
            ViewData["AssigneeId"] = new SelectList(_context.Users, "Id", "Id", jobTasks.AssigneeId);
            return View(jobTasks);
        }

        // GET: Invoice/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobTasks = await _context.JobTasks.FindAsync(id);
            if (jobTasks == null)
            {
                return NotFound();
            }
            ViewData["BusinessValueId"] = new SelectList(_context.BusinessValues, "Id", "Id", jobTasks.BusinessValueId);
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Id", jobTasks.ClientId);
            ViewData["JobId"] = new SelectList(_context.Jobs, "Id", "Id", jobTasks.JobId);
            ViewData["TaskId"] = new SelectList(_context.Tasks, "Id", "Id", jobTasks.TaskId);
            ViewData["AssigneeId"] = new SelectList(_context.Users, "Id", "Id", jobTasks.AssigneeId);
            return View(jobTasks);
        }

        // POST: Invoice/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DateCreated,Status,Description,TimeSpent,TaskId,JobId,ClientId,BusinessValueId,AssigneeId")] JobTasks jobTasks)
        {
            if (id != jobTasks.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jobTasks);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobTasksExists(jobTasks.Id))
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
            ViewData["BusinessValueId"] = new SelectList(_context.BusinessValues, "Id", "Id", jobTasks.BusinessValueId);
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Id", jobTasks.ClientId);
            ViewData["JobId"] = new SelectList(_context.Jobs, "Id", "Id", jobTasks.JobId);
            ViewData["TaskId"] = new SelectList(_context.Tasks, "Id", "Id", jobTasks.TaskId);
            ViewData["AssigneeId"] = new SelectList(_context.Users, "Id", "Id", jobTasks.AssigneeId);
            return View(jobTasks);
        }

        // GET: Invoice/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobTasks = await _context.JobTasks
                .Include(j => j.BusinessValue)
                .Include(j => j.Client)
                .Include(j => j.Job)
                .Include(j => j.Task)
                .Include(j => j.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jobTasks == null)
            {
                return NotFound();
            }

            return View(jobTasks);
        }

        // POST: Invoice/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jobTasks = await _context.JobTasks.FindAsync(id);
            _context.JobTasks.Remove(jobTasks);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JobTasksExists(int id)
        {
            return _context.JobTasks.Any(e => e.Id == id);
        }
    }
}
