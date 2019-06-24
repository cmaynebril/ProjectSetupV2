using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectSetupV2.Models;
using ProjectSetupV2.Models.Context;

namespace ProjectSetupV2.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly DBProjectSetupContext _context;

        public HomeController(DBProjectSetupContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //public ActionResult GetProjectsList(int projectsID)
        //{
        //    List<Projects> projects = new List<Projects>();
        //    int projectiD = Convert.ToInt32(projectsID);
        //    using (DBProjectSetupContext context = new DBProjectSetupContext())
        //    {
        //        projects = (context.Projects.Where(x => x.Id == projectsID)).ToList<Projects>();
        //    }
        //    JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
        //    string result = javaScriptSerializer.Serialize(projects);
        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}

        // GET: Home/Setup
        public IActionResult Setup()
        {
                var ClientList = _context.Clients.ToList();
                var dropdownClientList = new List<SelectListItem>();
                foreach (var customer in ClientList)
                {
                dropdownClientList.Add(new SelectListItem { Value = customer.Id.ToString(), Text = customer.Client.ToString()});
                }
                ViewBag.CustomerNameList = dropdownClientList;

                var BusinessValuesList = _context.BusinessValues.ToList();
                var dropdownBusinessValuesList = new List<SelectListItem>();
                foreach (var values in BusinessValuesList)
                {
                    dropdownBusinessValuesList.Add(new SelectListItem { Value = values.Business.ToString(), Text = values.Business.ToString() });
                }
                ViewBag.BusinessValuesList = dropdownBusinessValuesList;

                var ProjectsList = _context.Jobs.ToList();
                var dropdownProjectsList = new List<SelectListItem>();
                foreach (var projects in ProjectsList)
                {
                    dropdownProjectsList.Add(new SelectListItem { Value = projects.Id.ToString(), Text = projects.Job.ToString() });
                }
                ViewBag.ProjectList = dropdownProjectsList;

                var TasksList = _context.Tasks.ToList();
                var dropdownTasksList = new List<SelectListItem>();
                foreach (var tasks in TasksList)
                {
                    dropdownTasksList.Add(new SelectListItem { Value = tasks.Id.ToString(), Text = tasks.Task.ToString() });
                }
                ViewBag.TasksList = dropdownTasksList;

            return View();
        }

        // POST: Home/Setup
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Setup(SetupViewModel SetupViewModel)
        {
            if (ModelState.IsValid)
            {
                var validation = _context.Jobs.SingleOrDefault(x => x.Job.ToString() == SetupViewModel.Job && x.ClientId == SetupViewModel.CustomerId);
                if (validation != null)
                {
                    ModelState.AddModelError(string.Empty, "This project already exists.");

                    var ClientList = _context.Clients.ToList();
                    var dropdownClientList = new List<SelectListItem>();
                    foreach (var clients in ClientList)
                    {
                        dropdownClientList.Add(new SelectListItem { Value = clients.Id.ToString(), Text = clients.Client.ToString() });
                    }
                    ViewBag.CustomerNameList = dropdownClientList;

                    var BusinessValuesList = _context.BusinessValues.ToList();
                    var dropdownBusinessValuesList = new List<SelectListItem>();
                    foreach (var values in BusinessValuesList)
                    {
                        dropdownBusinessValuesList.Add(new SelectListItem { Value = values.Business.ToString(), Text = values.Business.ToString() });
                    }
                    ViewBag.BusinessValuesList = dropdownBusinessValuesList;
                    return View();
                }
                else
                {
                    Jobs jobs = new Jobs();
                    jobs.Job = SetupViewModel.Job;
                    jobs.ClientId = SetupViewModel.CustomerId;

                    var customer = _context.Clients.Where(x => x.Id == SetupViewModel.CustomerId).ToList();
                    foreach (var c in customer)
                    {
                        jobs.ClientName = c.Client;
                    }

                    _context.Add(jobs);
                    await _context.SaveChangesAsync();

                    var project = _context.Jobs.Where(x => x.Job.ToString() == SetupViewModel.Job.ToString() && x.ClientId == SetupViewModel.CustomerId).ToList();
                    var busval = _context.BusinessValues.Where(x => x.Business.ToString() == SetupViewModel.BusinessValue.ToString()).ToList();
                    for (int i = 0; i < SetupViewModel.TaskName.Length; i++)
                    {
                        Tasks tasks = new Tasks();
                        tasks.Task = SetupViewModel.TaskName[i];

                        foreach (var p in project)
                        {
                            tasks.JobId = p.Id;
                        }


                        foreach (var b in busval)
                        {
                            tasks.BusinessValuesId = b.Id;
                        }

                        _context.Add(tasks);
                        await _context.SaveChangesAsync();
                    }

                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }

            }
            return View(SetupViewModel);
        }
        public IActionResult Main()
        {
            var model = new MainViewModel();
            var customer = _context.Clients.ToList();
            foreach (var c in customer)
            {
                model.customers.Add(new xxCustomers { CustomerName = c.Client, Id = c.Id});
            }

            var project = _context.Jobs.ToList();
            foreach (var p in project)
            {
                model.jobs.Add(new xxJobs { Job = p.Job, CustomerId = p.ClientId, Id = p.Id});
            }

            var task = _context.Tasks.ToList();
            foreach (var t in task)
            {
                model.tasks.Add(new xxTasks { TaskName = t.Task, ProjectId = t.JobId, BusinessValuesId = t.BusinessValuesId });
            }

            var busval = _context.BusinessValues.ToList();
            foreach (var b in busval)
            {
                model.businessValues.Add(new xxBusinessValues { BusinessValue = b.Business, Business = b.Rate, Id = b.Id});
            }

            return View(model);
        }

        public IActionResult Timesheet()
        {
            return View();
        }
        public IActionResult Invoice()


        {
            var InvoiceType = _context.InvoiceType.ToList();
            var InvoiceTypeList = new List<SelectListItem>();
            foreach (var item in InvoiceType)
            {
                InvoiceTypeList.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.Type.ToString() });
            }
            ViewBag.InvoiceType = InvoiceTypeList;

            var model = new InvoiceViewModel();
            var joblist = _context.Jobs.Where(x => x.Status == "Done").ToList();
            foreach (var p in joblist)
            {
                model.jobs.Add(new iJobs { Job = p.Job, Id = p.Id , JobRate = p.JobRate});
            }

            var tasklist = _context.Tasks.Where(x => x.Status == "Done").ToList();
            foreach (var t in tasklist)
            {
                model.tasks.Add(new iTasks { Task = t.Task, Id = t.Id,  TasksRate= t.TasksRate });
            }

            var BusVallist = _context.BusinessValues.ToList();
            foreach (var b in BusVallist)
            {
                model.businessValues.Add(new iBusinessValues { Business = b.Business, Id = b.Id, Rate = b.Rate });
            }

            var userlist = _context.Users.ToList();
            foreach (var u in userlist)
            {
                model.user.Add(new iUser {Id = u.Id, UserName = u.UserName, Rate = u.Rate});
            }


            List<InvoiceType> invoices = new List<InvoiceType>();
            invoices = (from Type in _context.InvoiceType
                        select Type).ToList();
            invoices.Insert(0, new InvoiceType { Id = 0, Type = "Select" });
            ViewBag.InvoiceType = invoices;


            return View(model);
        }
        public JsonResult GetClientCategory(int Id)
        {
            List<Clients> ClientsList = new List<Clients>();
            ClientsList = (from client in _context.Clients
                           select client).ToList();
            ClientsList.Insert(0, new Clients { Id = 0, Client = "Select" });
            return Json(new SelectList(ClientsList, "Id", "Client"));
        }

    }

    
}
