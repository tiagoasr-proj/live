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
    public class InstrutoresController : Controller
    {
        private readonly AppDbContext _context;

        public InstrutoresController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Instrutores
        public async Task<IActionResult> Index(string filtro)
        {

            ViewData["FiltroAtual"] = filtro;
            var instrutores = from i in _context.Instrutores
                              select i;

            if (!String.IsNullOrEmpty(filtro))
            {
                instrutores = instrutores.Where(i => i.Nome.Contains(filtro)
                                       || i.Email.Contains(filtro)
                                       || i.Instagram.Contains(filtro)
                                       );
            }
            return View(await instrutores.AsNoTracking().ToListAsync());            
        }

        // GET: Instrutores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instrutores = await _context.Instrutores
                 .Include(i => i.Lives)         
                 .AsNoTracking()
                .FirstOrDefaultAsync(i => i.InstrutorId == id);

            if (instrutores == null)
            {
                return NotFound();
            }

            return View(instrutores);
        }

        // GET: Instrutores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Instrutores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InstrutorId,Nome,Email,Instagram,DataNascimento")] Instrutores instrutores)
        {
            if (ModelState.IsValid)
            {
                _context.Add(instrutores);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(instrutores);
        }

        // GET: Instrutores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instrutores = await _context.Instrutores.FindAsync(id);
            if (instrutores == null)
            {
                return NotFound();
            }
            return View(instrutores);
        }

        // POST: Instrutores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InstrutorId,Nome,Email,Instagram,DataNascimento")] Instrutores instrutores)
        {
            if (id != instrutores.InstrutorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(instrutores);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InstrutoresExists(instrutores.InstrutorId))
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
            return View(instrutores);
        }

        // GET: Instrutores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instrutores = await _context.Instrutores
                .FirstOrDefaultAsync(m => m.InstrutorId == id);
            if (instrutores == null)
            {
                return NotFound();
            }

            return View(instrutores);
        }

        // POST: Instrutores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var instrutores = await _context.Instrutores.FindAsync(id);
            _context.Instrutores.Remove(instrutores);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InstrutoresExists(int id)
        {
            return _context.Instrutores.Any(e => e.InstrutorId == id);
        }
    }
}
