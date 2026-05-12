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
        public async Task<IActionResult> Index()
        {
            var hoje = DateTime.Today;

            var caixa = await _context.Caixa
                .Include(c => c.Movimentacao)
                .FirstOrDefaultAsync( caixa => 
                caixa.DataAbertura == hoje &&
                caixa.Status == true
                );

            if (caixa == null)
            {
                return View("AbrirCaixa");
            }

            caixa.TotalEntradas = caixa.Movimentacao
                .Where(x => x.Tipo == "Entrada")
                .Sum(x => x.Valor);

            caixa.TotalSaidas = caixa.Movimentacao
                .Where(x => x.Tipo == "Saida")
                .Sum(x => x.Valor);

            caixa.Lucro = caixa.TotalEntradas - caixa.TotalSaidas;

            caixa.ValorFinal = caixa.ValorInicial + caixa.Lucro;

            await _context.SaveChangesAsync();

            return View("Dashbord", caixa);
        }

        [HttpPost]
        public async Task<IActionResult> AbrirCaixa(decimal valorInicial)
        {
            var caixa = new CaixaModel
            {
                DataAbertura = DateTime.Today,
                ValorInicial = valorInicial,
                Status = true
            };

            _context.Caixa.Add(caixa);

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public IActionResult AdicionarMovimentacao(int caixaId)
        {
            ViewBag.CaixaId = caixaId;
            return View("AdicionarMovimentacao");
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarMovimentacao(
            int CaixaId,
            string descricao,
            string tipo,
            decimal valor
            )
        {
            var caixa = await _context.Caixa
                .FirstOrDefaultAsync(c => c.Id == CaixaId);

            if (caixa == null)
            {
                return NotFound();
            }

            if (!caixa.Status)
            {
                return BadRequest("O caixa está fechado. Não é possível adicionar movimentações.");
            }

            var movimentacao = new MovimentacaoModel
            {
                CaixaId = CaixaId,
                Data = DateTime.Now,
                Descricao = descricao,
                Tipo = tipo,
                Valor = valor
            };

            _context.Movimentacao.Add(movimentacao);

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> FecharCaixa(int id)
        {
            var caixa = await _context.Caixa
                .Include(c => c.Movimentacao)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (caixa == null)
            {
                return NotFound();
            }

            caixa.TotalEntradas = caixa.Movimentacao
                .Where(x => x.Tipo == "Entrada")
                .Sum(x => x.Valor);

            caixa.TotalSaidas = caixa.Movimentacao
                .Where(x => x.Tipo == "Saida")
                .Sum(x => x.Valor);

            caixa.Lucro = caixa.TotalEntradas - caixa.TotalSaidas;

            caixa.ValorFinal = caixa.ValorInicial + caixa.Lucro;

            caixa.Status = false;

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Historico()
        {
            var caixas = await _context.Caixa
                .OrderByDescending(c => c.DataAbertura)
                .ToListAsync();

            return View(caixas);
        }
    }
}
