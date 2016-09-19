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
    public class CashDisbursementsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CashDisbursementsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: CashDisbursements
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.CashDisbursement.Include(c => c.CashAccount).Include(c => c.Employee).Include(c => c.Vendor);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: CashDisbursements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cashDisbursement = await _context.CashDisbursement.SingleOrDefaultAsync(m => m.CheckNumber == id);
            if (cashDisbursement == null)
            {
                return NotFound();
            }

            return View(cashDisbursement);
        }

        // GET: CashDisbursements/Create
        public IActionResult Create()
        {
            ViewData["CashAccountID"] = new SelectList(_context.CashAccount, "CashAccountID", "BankAccountNumber");
            ViewData["EmployeeID"] = new SelectList(_context.Set<Employee>(), "EmployeeID", "EmployeeFirstName");
            ViewData["VendorID"] = new SelectList(_context.Set<Vendor>(), "VendorID", "VendorAddress1");
            return View();
        }

        // POST: CashDisbursements/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CheckNumber,CashAccountID,CashDisbursementDate,EmployeeID,VendorID")] CashDisbursement cashDisbursement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cashDisbursement);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["CashAccountID"] = new SelectList(_context.CashAccount, "CashAccountID", "BankAccountNumber", cashDisbursement.CashAccountID);
            ViewData["EmployeeID"] = new SelectList(_context.Set<Employee>(), "EmployeeID", "EmployeeFirstName", cashDisbursement.EmployeeID);
            ViewData["VendorID"] = new SelectList(_context.Set<Vendor>(), "VendorID", "VendorAddress1", cashDisbursement.VendorID);
            return View(cashDisbursement);
        }

        // GET: CashDisbursements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cashDisbursement = await _context.CashDisbursement.SingleOrDefaultAsync(m => m.CheckNumber == id);
            if (cashDisbursement == null)
            {
                return NotFound();
            }
            ViewData["CashAccountID"] = new SelectList(_context.CashAccount, "CashAccountID", "BankAccountNumber", cashDisbursement.CashAccountID);
            ViewData["EmployeeID"] = new SelectList(_context.Set<Employee>(), "EmployeeID", "EmployeeFirstName", cashDisbursement.EmployeeID);
            ViewData["VendorID"] = new SelectList(_context.Set<Vendor>(), "VendorID", "VendorAddress1", cashDisbursement.VendorID);
            return View(cashDisbursement);
        }

        // POST: CashDisbursements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CheckNumber,CashAccountID,CashDisbursementDate,EmployeeID,VendorID")] CashDisbursement cashDisbursement)
        {
            if (id != cashDisbursement.CheckNumber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cashDisbursement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CashDisbursementExists(cashDisbursement.CheckNumber))
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
            ViewData["CashAccountID"] = new SelectList(_context.CashAccount, "CashAccountID", "BankAccountNumber", cashDisbursement.CashAccountID);
            ViewData["EmployeeID"] = new SelectList(_context.Set<Employee>(), "EmployeeID", "EmployeeFirstName", cashDisbursement.EmployeeID);
            ViewData["VendorID"] = new SelectList(_context.Set<Vendor>(), "VendorID", "VendorAddress1", cashDisbursement.VendorID);
            return View(cashDisbursement);
        }

        // GET: CashDisbursements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cashDisbursement = await _context.CashDisbursement.SingleOrDefaultAsync(m => m.CheckNumber == id);
            if (cashDisbursement == null)
            {
                return NotFound();
            }

            return View(cashDisbursement);
        }

        // POST: CashDisbursements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cashDisbursement = await _context.CashDisbursement.SingleOrDefaultAsync(m => m.CheckNumber == id);
            _context.CashDisbursement.Remove(cashDisbursement);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool CashDisbursementExists(int id)
        {
            return _context.CashDisbursement.Any(e => e.CheckNumber == id);
        }
    }
}
