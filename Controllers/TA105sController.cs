using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Anh105.Data;
using Anh105.Models;

namespace Anh105.Controllers
{
    public class TA105sController : Controller
    {
        private readonly AnhDBContext _context;

        public TA105sController(AnhDBContext context)
        {
            _context = context;
        }

        // GET: TA105s
        public async Task<IActionResult> Index()
        {
            return View(await _context.TA105.ToListAsync());
        }

        // GET: TA105s/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tA105 = await _context.TA105
                .FirstOrDefaultAsync(m => m.TAid == id);
            if (tA105 == null)
            {
                return NotFound();
            }

            return View(tA105);
        }

        // GET: TA105s/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TA105s/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TAid,TAName,TAGener")] TA105 tA105)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tA105);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tA105);
        }

        // GET: TA105s/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tA105 = await _context.TA105.FindAsync(id);
            if (tA105 == null)
            {
                return NotFound();
            }
            return View(tA105);
        }

        // POST: TA105s/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("TAid,TAName,TAGener")] TA105 tA105)
        {
            if (id != tA105.TAid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tA105);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TA105Exists(tA105.TAid))
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
            return View(tA105);
        }

        // GET: TA105s/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tA105 = await _context.TA105
                .FirstOrDefaultAsync(m => m.TAid == id);
            if (tA105 == null)
            {
                return NotFound();
            }

            return View(tA105);
        }

        // POST: TA105s/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var tA105 = await _context.TA105.FindAsync(id);
            _context.TA105.Remove(tA105);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TA105Exists(string id)
        {
            return _context.TA105.Any(e => e.TAid == id);
        }
    }
}
