using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Klinika2.Data;
using Klinika2.Models;

namespace Klinika2.Controllers
{
    public class NalazsController : Controller
    {
        private readonly Klinika2Context _context;

        public NalazsController(Klinika2Context context)
        {
            _context = context;
        }

        // GET: Nalazs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Nalaz
                .Include(n => n.Prijem).ThenInclude(p => p.Ljekar)
                .Include(n => n.Prijem).ThenInclude(p => p.Pacijent)
                .AsNoTracking()
                .ToListAsync()); 
        }

        // GET: Nalazs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nalaz = await _context.Nalaz
                .Include(n => n.Prijem).ThenInclude(p => p.Ljekar)
                .Include(n => n.Prijem).ThenInclude(p => p.Pacijent)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.PrijemID == id);
            if (nalaz == null)
            {
                return NotFound();
            }

            return View(nalaz);
        }

        // GET: Nalazs/Create
        public IActionResult Create()
        {
            PopulatePrijemDropDown();
            return View();
        }

        // POST: Nalazs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PrijemID,Opis")] Nalaz nalaz)
        {
            nalaz.DatumVrijeme = DateTime.Now;

            if (ModelState.IsValid)
            {
                _context.Add(nalaz);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            PopulatePrijemDropDown(nalaz.PrijemID);
            return View(nalaz);
        }

        // GET: Nalazs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            
            if (id == null)
            {
                return NotFound();
            }

            var nalaz = await _context.Nalaz.FindAsync(id);
            if (nalaz == null)
            {
                return NotFound();
            }
            return View(nalaz);
        }

        // POST: Nalazs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PrijemID,Opis")] Nalaz nalaz)
        {
            if (id != nalaz.PrijemID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nalaz);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NalazExists(nalaz.PrijemID))
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
            return View(nalaz);
        }

        private void PopulatePrijemDropDown(object selectedPrijem = null)
        {
            var prijemiQuery = from p in _context.Prijem
                                 orderby p.DatumVrijeme
                                 select p;
            ViewBag.Prijemi = new SelectList(prijemiQuery.AsNoTracking(), "Id", "DatumVrijeme", selectedPrijem);
        }



        // GET: Nalazs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nalaz = await _context.Nalaz
                .Include(n => n.Prijem).ThenInclude(p => p.Ljekar)
                .Include(n => n.Prijem).ThenInclude(p => p.Pacijent)
                .FirstOrDefaultAsync(m => m.PrijemID == id);
            if (nalaz == null)
            {
                return NotFound();
            }

            return View(nalaz);
        }

        // POST: Nalazs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nalaz = await _context.Nalaz.FindAsync(id);
            _context.Nalaz.Remove(nalaz);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NalazExists(int id)
        {
            return _context.Nalaz.Any(e => e.PrijemID == id);
        }
    }
}
