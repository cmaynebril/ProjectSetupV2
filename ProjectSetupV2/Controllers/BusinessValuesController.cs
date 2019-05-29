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
    public class BusinessValuesController : Controller
    {
        private readonly DBProjectSetupContext _context;

        public BusinessValuesController(DBProjectSetupContext context)
        {
            _context = context;
        }

        // GET: BusinessValues
        public async Task<IActionResult> Index()
        {
            return View(await _context.BusinessValues.ToListAsync());
        }

        // GET: BusinessValues/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var businessValues = await _context.BusinessValues
                .FirstOrDefaultAsync(m => m.Id == id);
            if (businessValues == null)
            {
                return NotFound();
            }

            return View(businessValues);
        }

        // GET: BusinessValues/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BusinessValues/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Business,Rate")] BusinessValues businessValues)
        {
            if (ModelState.IsValid)
            {
                _context.Add(businessValues);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(businessValues);
        }

        // GET: BusinessValues/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var businessValues = await _context.BusinessValues.FindAsync(id);
            if (businessValues == null)
            {
                return NotFound();
            }
            return View(businessValues);
        }

        // POST: BusinessValues/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Business,Rate")] BusinessValues businessValues)
        {
            if (id != businessValues.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(businessValues);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BusinessValuesExists(businessValues.Id))
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
            return View(businessValues);
        }

        // GET: BusinessValues/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var businessValues = await _context.BusinessValues
                .FirstOrDefaultAsync(m => m.Id == id);
            if (businessValues == null)
            {
                return NotFound();
            }

            return View(businessValues);
        }

        // POST: BusinessValues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var businessValues = await _context.BusinessValues.FindAsync(id);
            _context.BusinessValues.Remove(businessValues);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BusinessValuesExists(long id)
        {
            return _context.BusinessValues.Any(e => e.Id == id);
        }
    }
}
