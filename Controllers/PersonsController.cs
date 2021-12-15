using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Anh105.Models;
using Anh105.Data;

namespace Anh105.Controllers
{
    public class PersonsController : Controller
    {
        private readonly AnhDBContext _context;

        public PersonsController(AnhDBContext context)
        {
            _context = context;
        }

        // GET: Persons
        public async Task<IActionResult> Index()
        {
            return View(await _context.PersonsAnh.ToListAsync());
        }

        // GET: Persons/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personsAnh = await _context.PersonsAnh
                .FirstOrDefaultAsync(m => m.PersonID == id);
            if (personsAnh == null)
            {
                return NotFound();
            }

            return View(personsAnh);
        }

        // GET: Persons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Persons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PersonID,PersonName")] PersonsAnh personsAnh)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personsAnh);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(personsAnh);
        }

        // GET: Persons/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personsAnh = await _context.PersonsAnh.FindAsync(id);
            if (personsAnh == null)
            {
                return NotFound();
            }
            return View(personsAnh);
        }

        // POST: Persons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("PersonID,PersonName")] PersonsAnh personsAnh)
        {
            if (id != personsAnh.PersonID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personsAnh);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonsAnhExists(personsAnh.PersonID))
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
            return View(personsAnh);
        }

        // GET: Persons/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personsAnh = await _context.PersonsAnh
                .FirstOrDefaultAsync(m => m.PersonID == id);
            if (personsAnh == null)
            {
                return NotFound();
            }

            return View(personsAnh);
        }

        // POST: Persons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var personsAnh = await _context.PersonsAnh.FindAsync(id);
            _context.PersonsAnh.Remove(personsAnh);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonsAnhExists(string id)
        {
            return _context.PersonsAnh.Any(e => e.PersonID == id);
        }
    }
}
