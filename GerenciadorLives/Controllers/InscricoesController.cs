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

        private void filtroLives(object filtroLive = null)
        {
            var liveSelect = from l in _context.Lives
                                   orderby l.Nome
                                   select l;
            ViewBag.LiveId = new SelectList(liveSelect.AsNoTracking(), "LiveId", "Nome", filtroLive);
        }

        // GET: Inscricoes
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Inscricoes.Include(i => i.Inscrito).Include(i => i.Live);
            filtroLives();
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
            ViewData["Fator"] = inscricoes.FatorVencimento(inscricoes.DataVencimento, inscricoes.ValorInscricao.ToString()); 
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
        public async Task<IActionResult> Create([Bind("LiveId,InscritoId")] Inscricoes inscricoes)
        {

            if (ModelState.IsValid)
            {
                var lives = await _context.Lives.FindAsync(inscricoes.LiveId);
                inscricoes.ValorInscricao = lives.Valor;
                inscricoes.DataVencimento = lives.Data.AddDays(-2);
                _context.Add(inscricoes);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));            
                return RedirectToAction("Edit", new { ID = inscricoes.InscricaoId });               

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

            //inscricoes.FatorVencimento(DataVencimento,ValorInscricao.toS)

            if (inscricoes == null)
            {
                return NotFound();
            }
            //ViewData["InscritoId"] = new SelectList(_context.Inscritos, "InscritoId", "Nome", inscricoes.InscritoId);
            //ViewData["LiveId"] = new SelectList(_context.Lives, "LiveId", "Nome", inscricoes.LiveId);
            ViewData["Fator"] = inscricoes.FatorVencimento(inscricoes.DataVencimento,inscricoes.ValorInscricao.ToString());
            return View(inscricoes);
        }

        // POST: Inscricoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.    

        
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditIn(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }          

            var inscricoes = await _context.Inscricoes
            .Include(i => i.Inscrito)
            .Include(i => i.Live)
            .FirstOrDefaultAsync(m => m.InscricaoId == id);

            if (await TryUpdateModelAsync<Inscricoes>(inscricoes,
                "",
                i => i.StatusPagamento))
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
