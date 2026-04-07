using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema_Buffer_BH.Data;
using Sistema_Buffer_BH.Models;

namespace Sistema_Buffer_BH.Controllers
{
    public class CaixaController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CaixaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Caixa
        public IActionResult Index()
        {
            return View();
        }

        // GET: Caixa/details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Caixa == null)
            {
                return NotFound();
            }

            var caixaModel = await _context.Caixa
                .FirstOrDefaultAsync(m => m.Id == id);
            if (caixaModel == null)
            {
                return NotFound();
            }

            return View(caixaModel);
        }

        // GET: Caixa/Create
        public IActionResult Caixa_Inicial()
        {
            return View();
        }

        // POST: Caixa/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public IActionResult Caixa_Inicial(CaixaFakeModel caixamodel)
        {
            if (ModelState.IsValid)
            {
                var novo = new CaixaModel();
                novo.Forma = caixamodel.Tipo;
                novo.Valor = Convert.ToDouble(caixamodel.Valor);
                novo.Data = caixamodel.Data;

                _context.Add(novo);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(caixamodel);
        }

        // GET: Caixa/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Caixa == null)
            {
                return NotFound();
            }

            var caixaModel = await _context.Caixa.FindAsync(id);
            if (caixaModel == null)
            {
                return NotFound();
            }
            return View(caixaModel);
        }

        // POST: Caixa/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Entrada,Saida,Data,Pedido_Id")] CaixaModel caixaModel)
        {
            if (id != caixaModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Caixa.Update(caixaModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CaixaModelExists(caixaModel.Id))
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
            return View(caixaModel);
        }

        // GET: Caixa/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Caixa == null)
            {
                return NotFound();
            }

            var caixaModel = await _context.Caixa
                .FirstOrDefaultAsync(m => m.Id == id);
            if (caixaModel == null)
            {
                return NotFound();
            }

            return View(caixaModel);
        }

        // POST: Caixa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Caixa == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Caixa'  is null.");
            }
            var caixaModel = await _context.Caixa.FindAsync(id);
            if (caixaModel != null)
            {
                _context.Caixa.Remove(caixaModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CaixaModelExists(int id)
        {
            return (_context.Caixa?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public IActionResult Entrada()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Entrada([Bind("Id,Tipo,Valor,Data")] CaixaFakeModel caixamodel)
        {
            if (ModelState.IsValid)
            {
                var nuevo = new CaixaModel();
                nuevo.Forma = caixamodel.Tipo;
                nuevo.Valor = Convert.ToDouble(caixamodel.Valor);
                nuevo.Data = caixamodel.Data;

                _context.Add(nuevo);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(caixamodel);
        }

        public IActionResult Saida()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Saida([Bind("Id,Tipo,Valor,Data")] CaixaFakeModel caixamodel)
        {
            if (ModelState.IsValid)
            {
                var caixa = new CaixaModel();
                caixa.Forma = caixamodel.Tipo;
                caixa.Valor = Convert.ToDouble(caixamodel.Valor);
                caixa.Data = caixamodel.Data;

                _context.Add(caixa);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(caixamodel);
        }

        public IActionResult Pesquisar()
        {
            IEnumerable<CaixaModel>? caixa = _context.Caixa;
            return View(caixa);
        }
    }
}
