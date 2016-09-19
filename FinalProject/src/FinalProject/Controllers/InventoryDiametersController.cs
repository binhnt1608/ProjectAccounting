using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinalProject.Data;
using FinalProject.Models;

namespace FinalProject.Controllers
{
    public class InventoryDiametersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InventoryDiametersController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: InventoryDiameters
        public async Task<IActionResult> Index()
        {
            return View(await _context.InventoryDiameter.ToListAsync());
        }

        // GET: InventoryDiameters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventoryDiameter = await _context.InventoryDiameter.SingleOrDefaultAsync(m => m.InventoryDiameterID == id);
            if (inventoryDiameter == null)
            {
                return NotFound();
            }

            return View(inventoryDiameter);
        }

        // GET: InventoryDiameters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InventoryDiameters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InventoryDiameterID,InventoryDiameterCode,InventoryDiameterDescription")] InventoryDiameter inventoryDiameter)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inventoryDiameter);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(inventoryDiameter);
        }

        // GET: InventoryDiameters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventoryDiameter = await _context.InventoryDiameter.SingleOrDefaultAsync(m => m.InventoryDiameterID == id);
            if (inventoryDiameter == null)
            {
                return NotFound();
            }
            return View(inventoryDiameter);
        }

        // POST: InventoryDiameters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InventoryDiameterID,InventoryDiameterCode,InventoryDiameterDescription")] InventoryDiameter inventoryDiameter)
        {
            if (id != inventoryDiameter.InventoryDiameterID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inventoryDiameter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InventoryDiameterExists(inventoryDiameter.InventoryDiameterID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(inventoryDiameter);
        }

        // GET: InventoryDiameters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventoryDiameter = await _context.InventoryDiameter.SingleOrDefaultAsync(m => m.InventoryDiameterID == id);
            if (inventoryDiameter == null)
            {
                return NotFound();
            }

            return View(inventoryDiameter);
        }

        // POST: InventoryDiameters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inventoryDiameter = await _context.InventoryDiameter.SingleOrDefaultAsync(m => m.InventoryDiameterID == id);
            _context.InventoryDiameter.Remove(inventoryDiameter);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool InventoryDiameterExists(int id)
        {
            return _context.InventoryDiameter.Any(e => e.InventoryDiameterID == id);
        }
    }
}
