using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LawyerDiary.Data;
using LawyerDiary.Models;

namespace LawyerDiary.Controllers
{
    public class CaseDetailsController : Controller
    {
        private readonly LawyerDiaryContext _context;

        public CaseDetailsController(LawyerDiaryContext context)
        {
            _context = context;
        }

        // GET: CaseDetails
        public async Task<IActionResult> Index()
        {
            return View(await _context.CaseDetails.ToListAsync());
        }
        public async Task<IActionResult> ViewCase()
        {
            return View(await _context.CaseDetails.ToListAsync());
        }

        // GET: CaseDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var caseDetails = await _context.CaseDetails
                .FirstOrDefaultAsync(m => m.id == id);
            if (caseDetails == null)
            {
                return NotFound();
            }

            return View(caseDetails);
        }

        // GET: CaseDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CaseDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,MName,LType,Email,Contact")] CaseDetails caseDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(caseDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(caseDetails);
        }

        // GET: CaseDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var caseDetails = await _context.CaseDetails.FindAsync(id);
            if (caseDetails == null)
            {
                return NotFound();
            }
            return View(caseDetails);
        }

        // POST: CaseDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,MName,LType,Email,Contact")] CaseDetails caseDetails)
        {
            if (id != caseDetails.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(caseDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CaseDetailsExists(caseDetails.id))
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
            return View(caseDetails);
        }

        // GET: CaseDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var caseDetails = await _context.CaseDetails
                .FirstOrDefaultAsync(m => m.id == id);
            if (caseDetails == null)
            {
                return NotFound();
            }

            return View(caseDetails);
        }

        // POST: CaseDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var caseDetails = await _context.CaseDetails.FindAsync(id);
            _context.CaseDetails.Remove(caseDetails);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CaseDetailsExists(int id)
        {
            return _context.CaseDetails.Any(e => e.id == id);
        }
    }
}
