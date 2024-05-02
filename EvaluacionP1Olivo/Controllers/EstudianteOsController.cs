using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EvaluacionP1Olivo.Data;
using EvaluacionP1Olivo.Models;

namespace EvaluacionP1Olivo.Controllers
{
    public class EstudianteOsController : Controller
    {
        private readonly EvaluacionP1OlivoContext _context;

        public EstudianteOsController(EvaluacionP1OlivoContext context)
        {
            _context = context;
        }

        // GET: EstudianteOs
        public async Task<IActionResult> Index()
        {
            var evaluacionP1OlivoContext = _context.EstudianteO.Include(e => e.Carreras);
            return View(await evaluacionP1OlivoContext.ToListAsync());
        }

        // GET: EstudianteOs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudianteO = await _context.EstudianteO
                .Include(e => e.Carreras)
                .FirstOrDefaultAsync(m => m.id == id);
            if (estudianteO == null)
            {
                return NotFound();
            }

            return View(estudianteO);
        }

        // GET: EstudianteOs/Create
        public IActionResult Create()
        {
            ViewData["carreraID"] = new SelectList(_context.Set<Carrera>(), "CarreraNum", "CarreraNum");
            return View();
        }

        // POST: EstudianteOs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,nombre,numDecimal,verdadero,fecha,carreraID")] EstudianteO estudianteO)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estudianteO);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["carreraID"] = new SelectList(_context.Set<Carrera>(), "CarreraNum", "CarreraNum", estudianteO.carreraID);
            return View(estudianteO);
        }

        // GET: EstudianteOs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudianteO = await _context.EstudianteO.FindAsync(id);
            if (estudianteO == null)
            {
                return NotFound();
            }
            ViewData["carreraID"] = new SelectList(_context.Set<Carrera>(), "CarreraNum", "CarreraNum", estudianteO.carreraID);
            return View(estudianteO);
        }

        // POST: EstudianteOs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,nombre,numDecimal,verdadero,fecha,carreraID")] EstudianteO estudianteO)
        {
            if (id != estudianteO.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estudianteO);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstudianteOExists(estudianteO.id))
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
            ViewData["carreraID"] = new SelectList(_context.Set<Carrera>(), "CarreraNum", "CarreraNum", estudianteO.carreraID);
            return View(estudianteO);
        }

        // GET: EstudianteOs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudianteO = await _context.EstudianteO
                .Include(e => e.Carreras)
                .FirstOrDefaultAsync(m => m.id == id);
            if (estudianteO == null)
            {
                return NotFound();
            }

            return View(estudianteO);
        }

        // POST: EstudianteOs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estudianteO = await _context.EstudianteO.FindAsync(id);
            if (estudianteO != null)
            {
                _context.EstudianteO.Remove(estudianteO);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstudianteOExists(int id)
        {
            return _context.EstudianteO.Any(e => e.id == id);
        }
    }
}
