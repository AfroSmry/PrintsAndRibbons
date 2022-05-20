#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PrintsAndRibbons.Models;

namespace PrintsAndRibbons.Controllers
{
    public class PrintsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PrintsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Prints
        public async Task<IActionResult> Index()
        {
            return View(await _context.prints.ToListAsync());
        }

        // GET: Prints/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var print = await _context.prints
                .FirstOrDefaultAsync(m => m.Id == id);
            if (print == null)
            {
                return NotFound();
            }

            return View(print);
        }

        // GET: Prints/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Prints/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProductName,Description,Price")] Print print)
        {
            if (ModelState.IsValid)
            {
                _context.Add(print);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(print);
        }

        // GET: Prints/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var print = await _context.prints.FindAsync(id);
            if (print == null)
            {
                return NotFound();
            }
            return View(print);
        }

        // POST: Prints/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProductName,Description,Price")] Print print)
        {
            if (id != print.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(print);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrintExists(print.Id))
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
            return View(print);
        }

        // GET: Prints/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var print = await _context.prints
                .FirstOrDefaultAsync(m => m.Id == id);
            if (print == null)
            {
                return NotFound();
            }

            return View(print);
        }

        // POST: Prints/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var print = await _context.prints.FindAsync(id);
            _context.prints.Remove(print);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrintExists(int id)
        {
            return _context.prints.Any(e => e.Id == id);
        }
    }
}
