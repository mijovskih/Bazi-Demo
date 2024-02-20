using System;
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
    public class VehicleTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VehicleTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: VehicleTypes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.VehicleTypes.Include(v => v.Vehicle);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: VehicleTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.VehicleTypes == null)
            {
                return NotFound();
            }

            var vehicleType = await _context.VehicleTypes
                .Include(v => v.Vehicle)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicleType == null)
            {
                return NotFound();
            }

            return View(vehicleType);
        }

        // GET: VehicleTypes/Create
        public IActionResult Create()
        {
            ViewData["VehicleVIN"] = new SelectList(_context.Vehicles, "VIN", "VIN");
            return View();
        }

        // POST: VehicleTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,VehicleVIN")] VehicleType vehicleType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehicleType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["VehicleVIN"] = new SelectList(_context.Vehicles, "VIN", "VIN", vehicleType.VehicleVIN);
            return View(vehicleType);
        }

        // GET: VehicleTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.VehicleTypes == null)
            {
                return NotFound();
            }

            var vehicleType = await _context.VehicleTypes.FindAsync(id);
            if (vehicleType == null)
            {
                return NotFound();
            }
            ViewData["VehicleVIN"] = new SelectList(_context.Vehicles, "VIN", "VIN", vehicleType.VehicleVIN);
            return View(vehicleType);
        }

        // POST: VehicleTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,VehicleVIN")] VehicleType vehicleType)
        {
            if (id != vehicleType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehicleType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleTypeExists(vehicleType.Id))
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
            ViewData["VehicleVIN"] = new SelectList(_context.Vehicles, "VIN", "VIN", vehicleType.VehicleVIN);
            return View(vehicleType);
        }

        // GET: VehicleTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.VehicleTypes == null)
            {
                return NotFound();
            }

            var vehicleType = await _context.VehicleTypes
                .Include(v => v.Vehicle)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicleType == null)
            {
                return NotFound();
            }

            return View(vehicleType);
        }

        // POST: VehicleTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.VehicleTypes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.VehicleTypes'  is null.");
            }
            var vehicleType = await _context.VehicleTypes.FindAsync(id);
            if (vehicleType != null)
            {
                _context.VehicleTypes.Remove(vehicleType);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehicleTypeExists(int id)
        {
          return (_context.VehicleTypes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
