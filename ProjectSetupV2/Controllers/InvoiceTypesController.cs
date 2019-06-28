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
    public class InvoiceTypesController : Controller
    {
        private readonly DBProjectSetupContext _context;

        public InvoiceTypesController(DBProjectSetupContext context)
        {
            _context = context;
        }

        // GET: InvoiceTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.InvoiceType.ToListAsync());
        }

        // GET: InvoiceTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoiceType = await _context.InvoiceType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (invoiceType == null)
            {
                return NotFound();
            }

            return View(invoiceType);
        }

        // GET: InvoiceTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InvoiceTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Type")] InvoiceType invoiceType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(invoiceType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(invoiceType);
        }

        // GET: InvoiceTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoiceType = await _context.InvoiceType.FindAsync(id);
            if (invoiceType == null)
            {
                return NotFound();
            }
            return View(invoiceType);
        }

        // POST: InvoiceTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Type")] InvoiceType invoiceType)
        {
            if (id != invoiceType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(invoiceType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvoiceTypeExists(invoiceType.Id))
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
            return View(invoiceType);
        }

        // GET: InvoiceTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoiceType = await _context.InvoiceType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (invoiceType == null)
            {
                return NotFound();
            }

            return View(invoiceType);
        }

        // POST: InvoiceTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var invoiceType = await _context.InvoiceType.FindAsync(id);
            _context.InvoiceType.Remove(invoiceType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvoiceTypeExists(int id)
        {
            return _context.InvoiceType.Any(e => e.Id == id);
        }
    }
}
