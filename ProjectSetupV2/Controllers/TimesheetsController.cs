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
    public class TimesheetsController : Controller
    {
        private readonly DBProjectSetupContext _context;

        public TimesheetsController(DBProjectSetupContext context)
        {
            _context = context;
        }
        [Authorize]
        // GET: Timesheets
        //public async Task<IActionResult> Index()
        public IActionResult Index()
        {
            //var clientList = _context.Clients.ToList();
            //var dropdownclientList = new List<SelectListItem>();
            //foreach (var client in clientList)
            //{
            //    dropdownclientList.Add(new SelectListItem { Value = client.Id.ToString(), Text = client.Client.ToString() });
            //}
            //ViewBag.clientList = dropdownclientList;

            //var jobList = _context.Jobs.ToList();
            //var dropdownjobList = new List<SelectListItem>();
            //foreach (var job in jobList)
            //{
            //    dropdownjobList.Add(new SelectListItem { Value = job.Id.ToString(), Text = job.Job.ToString() });
            //}
            //ViewBag.jobList = dropdownjobList;

            //var taskList = _context.Tasks.ToList();
            //var dropdowntaskList = new List<SelectListItem>();
            //foreach (var task in taskList)
            //{
            //    dropdowntaskList.Add(new SelectListItem { Value = task.Id.ToString(), Text = task.Task.ToString()});
            //}
            //ViewBag.taskList = dropdowntaskList;

            var busValueList = _context.BusinessValues.ToList();
            var dropdownbusValueList = new List<SelectListItem>();
            foreach (var busVal in busValueList)
            {
                dropdownbusValueList.Add(new SelectListItem { Value = busVal.Id.ToString(), Text = busVal.Business.ToString() });
            }
            ViewBag.busValueList = dropdownbusValueList;

            var assigneesList = _context.Assignees.ToList();
            var dropdownassigneesList = new List<SelectListItem>();
            foreach (var assgn in assigneesList)
            {
                dropdownassigneesList.Add(new SelectListItem { Value = assgn.Id.ToString(), Text = assgn.Assignee.ToString() });
            }
            ViewBag.assigneesList = dropdownassigneesList;

            List<TimesheetsStatus> timesheetsStatus = new List<TimesheetsStatus>();
            timesheetsStatus = (from TimesheetsStatus in _context.TimesheetsStatus
                                select TimesheetsStatus).ToList();
            timesheetsStatus.Insert(0, new TimesheetsStatus { Id = 0, Status = "Select" });
            ViewBag.timesheetsStatus = timesheetsStatus;
            //return View();
            //return View(await _context.Timesheet.ToListAsync());

            List<Clients> clientList = new List<Clients>();
            clientList = (from Clients in _context.Clients
                          select Clients).ToList();
            clientList.Insert(0, new Clients { Id = 0, Client = "Select" });
            ViewBag.ListofClients = clientList;
            return View();
        }

        public JsonResult GetJobCategory (int Id)
        {
            List<Jobs> jobList = new List<Jobs>();
            jobList = (from job in _context.Jobs
                       where job.ClientId == Id
                       select job).ToList();
            jobList.Insert(0, new Jobs { Id = 0, Job = "Select" });
            return Json(new SelectList(jobList, "Id", "Job"));
        }
        public JsonResult GetTaskCategory(int Id)
        {
            List<Tasks> taskList = new List<Tasks>();
            taskList = (from task in _context.Tasks
                       where task.JobId == Id
                       select task).ToList();
            taskList.Insert(0, new Tasks { Id = 0, Task = "Select" });
            return Json(new SelectList(taskList, "Id", "Task"));
        }

        // GET: Timesheets/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timesheet = await _context.JobTasks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (timesheet == null)
            {
                return NotFound();
            }

            return View(timesheet);
        }

        // GET: Timesheets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Timesheets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TimesheetViewModel model)
        {
            if (ModelState.IsValid)
            {
                var jobtask = new JobTasks();
                jobtask.DateCreated = model.Date;
                jobtask.Status = model.Status;
                jobtask.Description = model.Description;
                jobtask.TimeSpent = model.TotalTime;
                jobtask.AssigneeId = model.AssigneeId;
                jobtask.BusinessValueId = model.BusinessValueId;
                jobtask.ClientId = model.ClientId;
                jobtask.JobId = model.JobId;
                jobtask.TaskId = model.TaskId;

                var dbjobtask = _context.Add(jobtask);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: Timesheets/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timesheet = await _context.JobTasks.FindAsync(id);
            if (timesheet == null)
            {
                return NotFound();
            }
            return View(timesheet);
        }

        // POST: Timesheets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Date,TaskId,Status,Description,TimeSpent,JobId,ClientId,BusinessValueId,AssigneeId")] JobTasks jobTasks)
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
                    if (!TimesheetExists(jobTasks.Id))
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
            return View(jobTasks);
        }

        // GET: Timesheets/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timesheet = await _context.JobTasks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (timesheet == null)
            {
                return NotFound();
            }

            return View(timesheet);
        }

        // POST: Timesheets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var timesheet = await _context.JobTasks.FindAsync(id);
            _context.JobTasks.Remove(timesheet);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TimesheetExists(long id)
        {
            return _context.JobTasks.Any(e => e.Id == id);
        }
    }
}
