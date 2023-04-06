using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Data;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class MainController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MainController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Main
        public async Task<IActionResult> Index()
        {
              return _context.One1 != null ? 
                          View(await _context.One1.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.One1'  is null.");
        }

        // GET: Main/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.One1 == null)
            {
                return NotFound();
            }

            var main = await _context.One1
                .FirstOrDefaultAsync(m => m.Id == id);
            if (main == null)
            {
                return NotFound();
            }

            return View(main);
        }

        // GET: Main/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Main/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NameOperator,NameVendor,NameProduct,UnitPrice,NumberOfKillos,Value,Portion,Remains,CreatedDateTime,Description")] Main main)
        {
            if (ModelState.IsValid)
            {
                _context.Add(main);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(main);
        }

        // GET: Main/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.One1 == null)
            {
                return NotFound();
            }

            var main = await _context.One1.FindAsync(id);
            if (main == null)
            {
                return NotFound();
            }
            return View(main);
        }

        // POST: Main/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NameOperator,NameVendor,NameProduct,UnitPrice,NumberOfKillos,Value,Portion,Remains,CreatedDateTime,Description")] Main main)
        {
            if (id != main.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(main);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MainExists(main.Id))
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
            return View(main);
        }

        // GET: Main/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.One1 == null)
            {
                return NotFound();
            }

            var main = await _context.One1
                .FirstOrDefaultAsync(m => m.Id == id);
            if (main == null)
            {
                return NotFound();
            }

            return View(main);
        }

        // POST: Main/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.One1 == null)
            {
                return Problem("Entity set 'ApplicationDbContext.One1'  is null.");
            }
            var main = await _context.One1.FindAsync(id);
            if (main != null)
            {
                _context.One1.Remove(main);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MainExists(int id)
        {
          return (_context.One1?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        public IActionResult Overlay()
        {   

            return View();
        }
    }
}
