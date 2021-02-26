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
    public class LivesController : Controller
    {
        private readonly AppDbContext _context;

        public LivesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Lives
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Lives.Include(l => l.Instrutor);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Lives/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lives = await _context.Lives
                .Include(l => l.Instrutor)
                .FirstOrDefaultAsync(m => m.LiveId == id);
            if (lives == null)
            {
                return NotFound();
            }

            return View(lives);
        }

        // GET: Lives/Create
        public IActionResult Create()
        {
            ViewData["InstrutorId"] = new SelectList(_context.Instrutores, "InstrutorId", "Nome");
            return View();
        }

        // POST: Lives/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LiveId,Nome,Descricao,InstrutorId,Data,Duracao,Valor")] Lives lives)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lives);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["InstrutorId"] = new SelectList(_context.Instrutores, "InstrutorId", "Nome", lives.InstrutorId);
            return View(lives);
        }

        // GET: Lives/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lives = await _context.Lives.FindAsync(id);
            if (lives == null)
            {
                return NotFound();
            }
            ViewData["InstrutorId"] = new SelectList(_context.Instrutores, "InstrutorId", "Nome", lives.InstrutorId);
            return View(lives);
        }

        // POST: Lives/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LiveId,Nome,Descricao,InstrutorId,Data,Duracao,Valor")] Lives lives)
        {
            if (id != lives.LiveId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lives);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LivesExists(lives.LiveId))
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
            ViewData["InstrutorId"] = new SelectList(_context.Instrutores, "InstrutorId", "Nome", lives.InstrutorId);
            return View(lives);
        }

        // GET: Lives/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lives = await _context.Lives
                .Include(l => l.Instrutor)
                .FirstOrDefaultAsync(m => m.LiveId == id);
            if (lives == null)
            {
                return NotFound();
            }

            return View(lives);
        }

        // POST: Lives/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lives = await _context.Lives.FindAsync(id);
            _context.Lives.Remove(lives);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LivesExists(int id)
        {
            return _context.Lives.Any(e => e.LiveId == id);
        }
    }
}
