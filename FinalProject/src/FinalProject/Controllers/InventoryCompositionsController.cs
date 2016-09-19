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
    public class InventoryCompositionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InventoryCompositionsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: InventoryCompositions
        public async Task<IActionResult> Index()
        {
            return View(await _context.InventoryComposition.ToListAsync());
        }

        // GET: InventoryCompositions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventoryComposition = await _context.InventoryComposition.SingleOrDefaultAsync(m => m.InventoryCompositionID == id);
            if (inventoryComposition == null)
            {
                return NotFound();
            }

            return View(inventoryComposition);
        }

        // GET: InventoryCompositions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InventoryCompositions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InventoryCompositionID,InventoryCompositionCode,InventoryCompositionDescription")] InventoryComposition inventoryComposition)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inventoryComposition);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(inventoryComposition);
        }

        // GET: InventoryCompositions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventoryComposition = await _context.InventoryComposition.SingleOrDefaultAsync(m => m.InventoryCompositionID == id);
            if (inventoryComposition == null)
            {
                return NotFound();
            }
            return View(inventoryComposition);
        }

        // POST: InventoryCompositions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InventoryCompositionID,InventoryCompositionCode,InventoryCompositionDescription")] InventoryComposition inventoryComposition)
        {
            if (id != inventoryComposition.InventoryCompositionID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inventoryComposition);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InventoryCompositionExists(inventoryComposition.InventoryCompositionID))
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
            return View(inventoryComposition);
        }

        // GET: InventoryCompositions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventoryComposition = await _context.InventoryComposition.SingleOrDefaultAsync(m => m.InventoryCompositionID == id);
            if (inventoryComposition == null)
            {
                return NotFound();
            }

            return View(inventoryComposition);
        }

        // POST: InventoryCompositions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inventoryComposition = await _context.InventoryComposition.SingleOrDefaultAsync(m => m.InventoryCompositionID == id);
            _context.InventoryComposition.Remove(inventoryComposition);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool InventoryCompositionExists(int id)
        {
            return _context.InventoryComposition.Any(e => e.InventoryCompositionID == id);
        }
    }
}
