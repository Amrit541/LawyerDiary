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
    public class LawyersController : Controller
    {
        private readonly LawyerDiaryContext _context;

        public LawyersController(LawyerDiaryContext context)
        {
            _context = context;
        }

        // GET: Lawyers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Lawyer.ToListAsync());
        }

        // GET: Lawyers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lawyer = await _context.Lawyer
                .FirstOrDefaultAsync(m => m.id == id);
            if (lawyer == null)
            {
                return NotFound();
            }

            return View(lawyer);
        }

        // GET: Lawyers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Lawyers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,MName,LType,Email,Password")] Lawyer lawyer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lawyer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lawyer);
        }

        // GET: Lawyers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lawyer = await _context.Lawyer.FindAsync(id);
            if (lawyer == null)
            {
                return NotFound();
            }
            return View(lawyer);
        }

        // POST: Lawyers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,MName,LType,Email,Password")] Lawyer lawyer)
        {
            if (id != lawyer.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lawyer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LawyerExists(lawyer.id))
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
            return View(lawyer);
        }

        // GET: Lawyers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lawyer = await _context.Lawyer
                .FirstOrDefaultAsync(m => m.id == id);
            if (lawyer == null)
            {
                return NotFound();
            }

            return View(lawyer);
        }

        // POST: Lawyers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lawyer = await _context.Lawyer.FindAsync(id);
            _context.Lawyer.Remove(lawyer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LawyerExists(int id)
        {
            return _context.Lawyer.Any(e => e.id == id);
        }
    }
}
