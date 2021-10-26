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
    public class PrijemsController : Controller
    {
        private readonly Klinika2Context _context;

        public PrijemsController(Klinika2Context context)
        {
            _context = context;
        }


        // GET: Prijems
        public async Task<IActionResult> Index()
        {
            return View(await _context.Prijem
                .Include(c => c.Ljekar)
                .Include(c => c.Pacijent)
                .AsNoTracking()
                .ToListAsync());
        }

        // GET: Prijems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prijem = await _context.Prijem
                .Include(c => c.Ljekar)
                .Include(c => c.Pacijent)
                .Include(c => c.Nalaz)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prijem == null)
            {
                return NotFound();
            }

            return View(prijem);
        }

        private void PopulateDropDownLists(object selectedLjekar = null, object selectedPacijent = null)
        {
            var ljekariQuery = from l in _context.Ljekar
                                   orderby l.Prezime
                                   select l;
            ViewBag.Ljekari = new SelectList(ljekariQuery.AsNoTracking(), "Id", "Prezime", selectedLjekar);

            var pacijentiQuery = from p in _context.Patients
                                    orderby p.ImePrezime
                                    select p;
            ViewBag.Pacijenti = new SelectList(pacijentiQuery.AsNoTracking(), "Id", "ImePrezime", selectedPacijent);
        }

        // GET: Prijems/Create
        public IActionResult Create(int? pacijentid)
        {
            if (pacijentid == null)
            {
                PopulateDropDownLists();
            }
            else
            {
                PopulateDropDownLists(null, pacijentid);
            }
            return View();
        }

        // POST: Prijems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DatumVrijeme,LjekarId,PacijentId,Hitno")] Prijem prijem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prijem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            PopulateDropDownLists(prijem.LjekarId, prijem.PacijentId);
            return View(prijem);
        }

        // GET: Prijems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prijem = await _context.Prijem.FindAsync(id);
            if (prijem == null)
            {
                return NotFound();
            }
            PopulateDropDownLists(prijem.LjekarId, prijem.PacijentId);
            return View(prijem);
        }

        // POST: Prijems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DatumVrijeme,LjekarId,PacijentId,Hitno")] Prijem prijem)
        {
            if (id != prijem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prijem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrijemExists(prijem.Id))
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
            PopulateDropDownLists(prijem.LjekarId, prijem.PacijentId);
            return View(prijem);
        }

        // GET: Prijems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prijem = await _context.Prijem
                .Include(c => c.Ljekar)
                .Include(c => c.Pacijent)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prijem == null)
            {
                return NotFound();
            }

            return View(prijem);
        }

        // POST: Prijems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var prijem = await _context.Prijem.FindAsync(id);
            _context.Prijem.Remove(prijem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrijemExists(int id)
        {
            return _context.Prijem.Any(e => e.Id == id);
        }
    }
}
