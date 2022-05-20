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
    public class RibbonsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RibbonsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Ribbons
        public async Task<IActionResult> Index()
        {
            return View(await _context.ribbons.ToListAsync());
        }

        // GET: Ribbons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ribbon = await _context.ribbons
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ribbon == null)
            {
                return NotFound();
            }

            return View(ribbon);
        }

        // GET: Ribbons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ribbons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProductName,Description,Price")] Ribbon ribbon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ribbon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ribbon);
        }

        // GET: Ribbons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ribbon = await _context.ribbons.FindAsync(id);
            if (ribbon == null)
            {
                return NotFound();
            }
            return View(ribbon);
        }

        // POST: Ribbons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProductName,Description,Price")] Ribbon ribbon)
        {
            if (id != ribbon.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ribbon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RibbonExists(ribbon.Id))
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
            return View(ribbon);
        }

        // GET: Ribbons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ribbon = await _context.ribbons
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ribbon == null)
            {
                return NotFound();
            }

            return View(ribbon);
        }

        // POST: Ribbons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ribbon = await _context.ribbons.FindAsync(id);
            _context.ribbons.Remove(ribbon);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RibbonExists(int id)
        {
            return _context.ribbons.Any(e => e.Id == id);
        }
    }
}
