using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RentalKendaraan_111.Models;

namespace RentalKendaraan_111.Controllers
{
    public class KostumersController : Controller
    {
        private readonly RentKendaraanContext _context;

        public KostumersController(RentKendaraanContext context)
        {
            _context = context;
        }

        // GET: Kostumers
        public async Task<IActionResult> Index()
        {
            var rentKendaraanContext = _context.Kostumer.Include(k => k.IdGenderNavigation);
            return View(await rentKendaraanContext.ToListAsync());
        }

        // GET: Kostumers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kostumer = await _context.Kostumer
                .Include(k => k.IdGenderNavigation)
                .FirstOrDefaultAsync(m => m.IdCostumer == id);
            if (kostumer == null)
            {
                return NotFound();
            }

            return View(kostumer);
        }

        // GET: Kostumers/Create
        public IActionResult Create()
        {
            ViewData["IdGender"] = new SelectList(_context.Gender, "IdGender", "IdGender");
            return View();
        }

        // POST: Kostumers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCostumer,NamaCostumer,Nik,Alamat,NoHp,IdGender")] Kostumer kostumer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kostumer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdGender"] = new SelectList(_context.Gender, "IdGender", "IdGender", kostumer.IdGender);
            return View(kostumer);
        }

        // GET: Kostumers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kostumer = await _context.Kostumer.FindAsync(id);
            if (kostumer == null)
            {
                return NotFound();
            }
            ViewData["IdGender"] = new SelectList(_context.Gender, "IdGender", "IdGender", kostumer.IdGender);
            return View(kostumer);
        }

        // POST: Kostumers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCostumer,NamaCostumer,Nik,Alamat,NoHp,IdGender")] Kostumer kostumer)
        {
            if (id != kostumer.IdCostumer)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kostumer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KostumerExists(kostumer.IdCostumer))
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
            ViewData["IdGender"] = new SelectList(_context.Gender, "IdGender", "IdGender", kostumer.IdGender);
            return View(kostumer);
        }

        // GET: Kostumers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kostumer = await _context.Kostumer
                .Include(k => k.IdGenderNavigation)
                .FirstOrDefaultAsync(m => m.IdCostumer == id);
            if (kostumer == null)
            {
                return NotFound();
            }

            return View(kostumer);
        }

        // POST: Kostumers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kostumer = await _context.Kostumer.FindAsync(id);
            _context.Kostumer.Remove(kostumer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KostumerExists(int id)
        {
            return _context.Kostumer.Any(e => e.IdCostumer == id);
        }
    }
}
