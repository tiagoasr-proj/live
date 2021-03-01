using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GerenciadorLives.Models;

namespace GerenciadorLives.Controllers
{
    public class InscritosController : Controller
    {
        private readonly AppDbContext _context;

        public InscritosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Inscritos
        public async Task<IActionResult> Index(string filtro)
        {
            ViewData["FiltroAtual"] = filtro;
            var inscritos = from i in _context.Inscritos
                              select i;

            if (!String.IsNullOrEmpty(filtro))
            {
                inscritos = inscritos.Where(i => i.Nome.Contains(filtro)
                                       || i.Email.Contains(filtro)
                                       || i.Instagram.Contains(filtro)
                                       );
            }
            return View(await inscritos.AsNoTracking().ToListAsync());
        }

        // GET: Inscritos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inscritos = await _context.Inscritos
                .Include(i => i.Inscricoes)
                    .ThenInclude(i => i.Live)
                    .FirstOrDefaultAsync(m => m.InscritoId == id);

            if (inscritos == null)
            {
                return NotFound();
            }

            return View(inscritos);
        }

        // GET: Inscritos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Inscritos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InscritoId,Nome,Email,Instagram,DataNascimento")] Inscritos inscritos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inscritos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(inscritos);
        }

        // GET: Inscritos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inscritos = await _context.Inscritos.FindAsync(id);
            if (inscritos == null)
            {
                return NotFound();
            }
            return View(inscritos);
        }

        // POST: Inscritos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InscritoId,Nome,Email,Instagram,DataNascimento")] Inscritos inscritos)
        {
            if (id != inscritos.InscritoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inscritos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InscritosExists(inscritos.InscritoId))
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
            return View(inscritos);
        }

        // GET: Inscritos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inscritos = await _context.Inscritos
                .FirstOrDefaultAsync(m => m.InscritoId == id);
            if (inscritos == null)
            {
                return NotFound();
            }

            return View(inscritos);
        }

        // POST: Inscritos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inscritos = await _context.Inscritos.FindAsync(id);
            _context.Inscritos.Remove(inscritos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InscritosExists(int id)
        {
            return _context.Inscritos.Any(e => e.InscritoId == id);
        }
    }
}
