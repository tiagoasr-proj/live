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
    public class InscricoesController : Controller
    {
        private readonly AppDbContext _context;

        public InscricoesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Inscricoes
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Inscricoes.Include(i => i.Inscrito).Include(i => i.Live);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Inscricoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inscricoes = await _context.Inscricoes
                .Include(i => i.Inscrito)
                .Include(i => i.Live)
                .FirstOrDefaultAsync(m => m.InscricaoId == id);
            if (inscricoes == null)
            {
                return NotFound();
            }

            return View(inscricoes);
        }

        // GET: Inscricoes/Create
        public IActionResult Create()
        {
            ViewData["InscritoId"] = new SelectList(_context.Inscritos, "InscritoId", "Nome");
            ViewData["LiveId"] = new SelectList(_context.Lives, "LiveId", "Nome");
            return View();
        }

        // POST: Inscricoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InscricaoId,LiveId,InscritoId,Pago,Boleto")] Inscricoes inscricoes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inscricoes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["InscritoId"] = new SelectList(_context.Inscritos, "InscritoId", "Nome", inscricoes.InscritoId);
            ViewData["LiveId"] = new SelectList(_context.Lives, "LiveId", "Nome", inscricoes.LiveId);
            return View(inscricoes);
        }

        // GET: Inscricoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var inscricoes = await _context.Inscricoes.FindAsync(id);
            //var inscricoes = await _context.Inscricoes.FindAsync(id);
            var inscricoes = await _context.Inscricoes
            .Include(i => i.Inscrito)
            .Include(i => i.Live)
            .FirstOrDefaultAsync(m => m.InscricaoId == id);

            if (inscricoes == null)
            {
                return NotFound();
            }
            //ViewData["InscritoId"] = new SelectList(_context.Inscritos, "InscritoId", "Nome", inscricoes.InscritoId);
            //ViewData["LiveId"] = new SelectList(_context.Lives, "LiveId", "Nome", inscricoes.LiveId);
            return View(inscricoes);
        }

        // POST: Inscricoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
     

        /*
        public async Task<IActionResult> Edit(int id, [Bind("InscricaoId,LiveId,InscritoId,Pago,Boleto")] Inscricoes inscricoes)
        {
            if (id != inscricoes.InscricaoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inscricoes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InscricoesExists(inscricoes.InscricaoId))
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
            ViewData["InscritoId"] = new SelectList(_context.Inscritos, "InscritoId", "Nome", inscricoes.InscritoId);
            ViewData["LiveId"] = new SelectList(_context.Lives, "LiveId", "Nome", inscricoes.LiveId);
            return View(inscricoes);
        }
        */
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditIn(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var courseToUpdate = await _context.Courses
            //    .FirstOrDefaultAsync(c => c.CourseID == id);

            var inscricoes = await _context.Inscricoes
            .Include(i => i.Inscrito)
            .Include(i => i.Live)
            .FirstOrDefaultAsync(m => m.InscricaoId == id);

            if (await TryUpdateModelAsync<Inscricoes>(inscricoes,
                "",
                i => i.Pago))
            {
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException /* ex */)
                {
                    //Log the error (uncomment ex variable name and write a log.)
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.");
                }
                return RedirectToAction(nameof(Index));
            }
            //PopulateDepartmentsDropDownList(courseToUpdate.DepartmentID);
            return View(inscricoes);
        }

        // GET: Inscricoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inscricoes = await _context.Inscricoes
                .Include(i => i.Inscrito)
                .Include(i => i.Live)
                .FirstOrDefaultAsync(m => m.InscricaoId == id);
            if (inscricoes == null)
            {
                return NotFound();
            }

            return View(inscricoes);
        }

        // POST: Inscricoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inscricoes = await _context.Inscricoes.FindAsync(id);
            _context.Inscricoes.Remove(inscricoes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InscricoesExists(int id)
        {
            return _context.Inscricoes.Any(e => e.InscricaoId == id);
        }
    }
}
