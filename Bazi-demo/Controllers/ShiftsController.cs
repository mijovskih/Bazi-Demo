﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bazi_demo.Data;
using Bazi_demo.Models;

namespace Bazi_demo.Controllers
{
    public class ShiftsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ShiftsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Shifts
        public async Task<IActionResult> Index()
        {
              return _context.Shifts != null ? 
                          View(await _context.Shifts.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Shifts'  is null.");
        }

        // GET: Shifts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Shifts == null)
            {
                return NotFound();
            }

            var shift = await _context.Shifts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shift == null)
            {
                return NotFound();
            }

            return View(shift);
        }

        // GET: Shifts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Shifts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,From,To")] Shift shift)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shift);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shift);
        }

        // GET: Shifts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Shifts == null)
            {
                return NotFound();
            }

            var shift = await _context.Shifts.FindAsync(id);
            if (shift == null)
            {
                return NotFound();
            }
            return View(shift);
        }

        // POST: Shifts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,From,To")] Shift shift)
        {
            if (id != shift.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shift);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShiftExists(shift.Id))
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
            return View(shift);
        }

        // GET: Shifts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Shifts == null)
            {
                return NotFound();
            }

            var shift = await _context.Shifts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shift == null)
            {
                return NotFound();
            }

            return View(shift);
        }

        // POST: Shifts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Shifts == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Shifts'  is null.");
            }
            var shift = await _context.Shifts.FindAsync(id);
            if (shift != null)
            {
                _context.Shifts.Remove(shift);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShiftExists(int id)
        {
          return (_context.Shifts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
