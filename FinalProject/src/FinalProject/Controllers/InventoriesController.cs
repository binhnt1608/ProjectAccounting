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
    public class InventoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InventoriesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Inventories
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Inventory.Include(i => i.InventoryComposition).Include(i => i.InventoryDiameter).Include(i => i.InventoryType);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Inventories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventory = await _context.Inventory.SingleOrDefaultAsync(m => m.InventoryID == id);
            if (inventory == null)
            {
                return NotFound();
            }

            return View(inventory);
        }

        // GET: Inventories/Create
        public IActionResult Create()
        {
            ViewData["InventoryCompositionID"] = new SelectList(_context.Set<InventoryComposition>(), "InventoryCompositionID", "InventoryCompositionID");
            ViewData["InventoryDiameterID"] = new SelectList(_context.Set<InventoryDiameter>(), "InventoryDiameterID", "InventoryDiameterID");
            ViewData["InventoryTypeID"] = new SelectList(_context.Set<InventoryType>(), "InventoryTypeID", "InventoryTypeID");
            return View();
        }

        // POST: Inventories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InventoryID,InventoryCompositionID,InventoryDescription,InventoryDiameterID,InventoryListPrice,InventoryTypeID")] Inventory inventory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inventory);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["InventoryCompositionID"] = new SelectList(_context.Set<InventoryComposition>(), "InventoryCompositionID", "InventoryCompositionID", inventory.InventoryCompositionID);
            ViewData["InventoryDiameterID"] = new SelectList(_context.Set<InventoryDiameter>(), "InventoryDiameterID", "InventoryDiameterID", inventory.InventoryDiameterID);
            ViewData["InventoryTypeID"] = new SelectList(_context.Set<InventoryType>(), "InventoryTypeID", "InventoryTypeID", inventory.InventoryTypeID);
            return View(inventory);
        }

        // GET: Inventories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventory = await _context.Inventory.SingleOrDefaultAsync(m => m.InventoryID == id);
            if (inventory == null)
            {
                return NotFound();
            }
            ViewData["InventoryCompositionID"] = new SelectList(_context.Set<InventoryComposition>(), "InventoryCompositionID", "InventoryCompositionID", inventory.InventoryCompositionID);
            ViewData["InventoryDiameterID"] = new SelectList(_context.Set<InventoryDiameter>(), "InventoryDiameterID", "InventoryDiameterID", inventory.InventoryDiameterID);
            ViewData["InventoryTypeID"] = new SelectList(_context.Set<InventoryType>(), "InventoryTypeID", "InventoryTypeID", inventory.InventoryTypeID);
            return View(inventory);
        }

        // POST: Inventories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InventoryID,InventoryCompositionID,InventoryDescription,InventoryDiameterID,InventoryListPrice,InventoryTypeID")] Inventory inventory)
        {
            if (id != inventory.InventoryID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inventory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InventoryExists(inventory.InventoryID))
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
            ViewData["InventoryCompositionID"] = new SelectList(_context.Set<InventoryComposition>(), "InventoryCompositionID", "InventoryCompositionID", inventory.InventoryCompositionID);
            ViewData["InventoryDiameterID"] = new SelectList(_context.Set<InventoryDiameter>(), "InventoryDiameterID", "InventoryDiameterID", inventory.InventoryDiameterID);
            ViewData["InventoryTypeID"] = new SelectList(_context.Set<InventoryType>(), "InventoryTypeID", "InventoryTypeID", inventory.InventoryTypeID);
            return View(inventory);
        }

        // GET: Inventories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventory = await _context.Inventory.SingleOrDefaultAsync(m => m.InventoryID == id);
            if (inventory == null)
            {
                return NotFound();
            }

            return View(inventory);
        }

        // POST: Inventories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inventory = await _context.Inventory.SingleOrDefaultAsync(m => m.InventoryID == id);
            _context.Inventory.Remove(inventory);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool InventoryExists(int id)
        {
            return _context.Inventory.Any(e => e.InventoryID == id);
        }
    }
}
