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
    public class LjekarsController : Controller
    {
        private readonly Klinika2Context _context;

        public LjekarsController(Klinika2Context context)
        {
            _context = context;
        }

        // GET: Ljekars
        public async Task<IActionResult> Index(string searchString)
        {
            var ljekari = from l in _context.Ljekar
                          select l;

            if (!String.IsNullOrEmpty(searchString))
            {
                ljekari = ljekari.Where(s => s.Prezime.Contains(searchString) || s.Ime.Contains(searchString));
            }

            return View(await ljekari.ToListAsync());




            return View(await _context.Ljekar.ToListAsync());
        }

        // GET: Ljekars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ljekar = await _context.Ljekar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ljekar == null)
            {
                return NotFound();
            }

            return View(ljekar);
        }

        // GET: Ljekars/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ljekars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ime,Prezime,Titula,Sifra")] Ljekar ljekar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ljekar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ljekar);
        }

        // GET: Ljekars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ljekar = await _context.Ljekar.FindAsync(id);
            if (ljekar == null)
            {
                return NotFound();
            }
            return View(ljekar);
        }

        // POST: Ljekars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ime,Prezime,Titula,Sifra")] Ljekar ljekar)
        {
            if (id != ljekar.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ljekar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LjekarExists(ljekar.Id))
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
            return View(ljekar);
        }

        // GET: Ljekars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ljekar = await _context.Ljekar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ljekar == null)
            {
                return NotFound();
            }

            return View(ljekar);
        }

        // POST: Ljekars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ljekar = await _context.Ljekar.FindAsync(id);
            _context.Ljekar.Remove(ljekar);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LjekarExists(int id)
        {
            return _context.Ljekar.Any(e => e.Id == id);
        }
    }
}
